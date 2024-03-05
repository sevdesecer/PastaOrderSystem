using AutoMapper;
using PastaOrderSystem.Context;
using PastaOrderSystem.DTO;
using PastaOrderSystem.Service.Base;
using PastaOrderSystem.Service.Beverage;
using PastaOrderSystem.Service.ExtraIngredient;
using PastaOrderSystem.Service.Junction;
using PastaOrderSystem.Service.Pasta;
using System.Linq.Expressions;

namespace PastaOrderSystem.Service.Order
{
    public class OrderService(IMapper mapper, DataContext context, IJunctionService junctionService, IPastaService pastaService, IBeverageService beverageService, IExtraIngredientService extraIngredientService) : BaseService<Entity.Order, OrderDto>(mapper, context), IOrderService
    {
        public void AddJunction(OrderDto model)
        {
            var order = new OrderDto
            {
                CustomerName = model.CustomerName,
                CustomerAddress = model.CustomerAddress,
                Pastas = []
            };

            if (model.Pastas != null && model.Pastas.Count != 0)
            {
                Expression<Func<Entity.Pasta, bool>> pastaFilter = p => model.Pastas.Select(o => o.Id).Contains(p.Id);
                var pastas = pastaService.GetByFilter(pastaFilter);
                order.Pastas = pastas.ToList();

                foreach (var pasta in model.Pastas)
                {
                    if(pasta.ExtraIngredients != null && pasta.ExtraIngredients.Count != 0)
                    {
                        Expression<Func<Entity.ExtraIngredient, bool>> extraIngredientFilter = p => pasta.ExtraIngredients.Select(o => o.Id).Contains(p.Id);
                        var extraIngredients = extraIngredientService.GetByFilter(extraIngredientFilter);
                        var pastaToAddExtraIngredients = order.Pastas.Find(p => p.Id == pasta.Id);
                        if (pastaToAddExtraIngredients != null)
                            pastaToAddExtraIngredients.ExtraIngredients = extraIngredients.ToList();
                    }
                }
            }

            if (model.Beverages != null && model.Beverages.Count != 0)
            {
                Expression<Func<Entity.Beverage, bool>> beverageFilter = b => model.Beverages.Select(o => o.Id).Contains(b.Id);
                var beverages = beverageService.GetByFilter(beverageFilter);
                order.Beverages = beverages.ToList();
            }

            model = order;
            var orderId = Guid.NewGuid();
            model.Id = orderId;
            model.DateTime = DateTime.UtcNow;
            model.TotalPrice = CalculateTotalPrice(model);

            var junctions = new List<JunctionDto>();

            // Loop through each pasta in the order if Pastas is not null
            if (model.Pastas != null && model.Pastas.Count != 0)
            {
                foreach (var pasta in model.Pastas)
                {
                    int pastaCount = junctions.Count(j => j.PastaId == pasta.Id);
                    int pastaNumber = pastaCount > 0 ? pastaCount + 1 : 1;

                    // Loop through each extra ingredient for the pasta if ExtraIngredients is not null
                    if (pasta.ExtraIngredients != null && pasta.ExtraIngredients.Count != 0)
                    {
                        foreach (var extraIngredient in pasta.ExtraIngredients)
                        {
                            var junction = new JunctionDto
                            {
                                OrderId = orderId,
                                PastaId = pasta.Id,
                                ExtraIngredientId = extraIngredient.Id,
                                PastaNumber = pastaNumber
                            };
                            junctions.Add(junction);
                        }
                    }
                }
            }

            // Loop through each beverage in the order if Beverages is not null
            if (model.Beverages != null && model.Beverages.Count != 0)
            {
                foreach (BeverageDto beverage in model.Beverages)
                {
                    var junction = new JunctionDto
                    {
                        OrderId = model.Id,
                        BeverageId = beverage.Id
                    };
                    junctions.Add(junction);
                }
            }

            Add(model, false);
            junctionService.AddRange(junctions, false);
            unitOfWork.SaveChanges();
        }  
       
        private static int CalculateTotalPrice(OrderDto orderDto)
        {
            var totalPrice = 0;
            if (orderDto.Pastas != null && orderDto.Pastas.Count != 0)
            {
                foreach (var pasta in orderDto.Pastas)
                {
                    totalPrice += pasta.Price ?? 0;

                    if (pasta.ExtraIngredients != null && pasta.ExtraIngredients.Count != 0) {
                        foreach (var extraIngredient in pasta.ExtraIngredients)
                        {
                            totalPrice += extraIngredient.Price ?? 0;
                        }
                    }
                }
            }
            if(orderDto.Beverages != null && orderDto.Beverages.Count != 0)
            {
                foreach (var beverage in orderDto.Beverages)
                {
                    totalPrice += beverage.Price ?? 0;
                }
            }
            return totalPrice;
        }
    }

}


