using AutoMapper;
using WebApi.Context;
using WebApi.DTO;
using WebApi.Service.Base;
using WebApi.Service.Beverage;
using WebApi.Service.ExtraIngredient;
using WebApi.Service.Junction;
using WebApi.Service.Pasta;
using System.Linq.Expressions;

namespace WebApi.Service.Order
{
    public class OrderService(IMapper mapper, DataContext context, IJunctionService junctionService, IPastaService pastaService, IBeverageService beverageService, IExtraIngredientService extraIngredientService) : BaseService<Entity.Order, OrderDto>(mapper, context), IOrderService
    {
        public async Task AddJunction(OrderDto model)
        {
            var order = new OrderDto
            {
                CustomerName = model.CustomerName,
                CustomerAddress = model.CustomerAddress,
                Pastas = [],
                Beverages = []
            };

            if (model.Pastas is not null && model.Pastas.Count is not 0)
            {
                var pastaIdListToCalculatePastaNumber = new List<Guid>();
                foreach (var pastaFromUser in model.Pastas)
                {
                    var pastaFromDb = pastaService.GetById(pastaFromUser.Id);

                    if (pastaFromUser.ExtraIngredients is not null && pastaFromUser.ExtraIngredients.Count is not 0)
                    {
                        Expression<Func<Entity.ExtraIngredient, bool>> extraIngredientFilter = p => pastaFromUser.ExtraIngredients.Select(o => o.Id).Contains(p.Id);

                        var extraIngredients = extraIngredientService.GetByFilter(extraIngredientFilter);

                        pastaFromDb.ExtraIngredients = extraIngredients.ToList();
                    }

                    pastaFromDb.Number = pastaIdListToCalculatePastaNumber.Count(p => p == pastaFromDb.Id) + 1;
                    pastaIdListToCalculatePastaNumber.Add(pastaFromDb.Id);

                    order.Pastas.Add(pastaFromDb);
                }
            }

            if (model.Beverages is not null && model.Beverages.Count is not 0)
            {
                foreach(var beverageFromUser in model.Beverages)
                {
                    var beverageFromDb = beverageService.GetById(beverageFromUser.Id);
                    order.Beverages.Add(beverageFromDb);
                }
                
            }

            var orderId = Guid.NewGuid();
            order.Id = orderId;
            order.DateTime = DateTime.UtcNow;
            order.TotalPrice = CalculateTotalPrice(order);

            var junctions = new List<JunctionDto>();

            // Loop through each pasta in the order if Pastas is not null
            if (order.Pastas is not null && order.Pastas.Count is not 0)
            {
                foreach (var pasta in order.Pastas)
                {
                    // Loop through each extra ingredient for the pasta if ExtraIngredients is not null
                    if (pasta.ExtraIngredients is not null && pasta.ExtraIngredients.Count is not 0)
                    {
                        foreach (var extraIngredient in pasta.ExtraIngredients)
                        {
                            var junction = new JunctionDto
                            {
                                OrderId = orderId,
                                PastaId = pasta.Id,
                                ExtraIngredientId = extraIngredient.Id,
                                PastaNumber = pasta.Number
                            };
                            junctions.Add(junction);
                        }
                    }
                    else
                    {
                        var junction = new JunctionDto
                        {
                            OrderId = orderId,
                            PastaId = pasta.Id,
                            PastaNumber = pasta.Number
                        };
                        junctions.Add(junction);
                    }
                }
            }

            // Loop through each beverage in the order if Beverages is not null
            if (order.Beverages is not null && order.Beverages.Count is not 0)
            {
                foreach (BeverageDto beverage in order.Beverages)
                {
                    var junction = new JunctionDto
                    {
                        OrderId = order.Id,
                        BeverageId = beverage.Id
                    };
                    junctions.Add(junction);
                }
            }

            await AddAsync(order, false).ConfigureAwait(false);
            await junctionService.AddRangeAsync(junctions, false).ConfigureAwait(false);
            await unitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }  
       
        private static int CalculateTotalPrice(OrderDto orderDto)
        {
            var totalPrice = 0;
            if (orderDto.Pastas is not null && orderDto.Pastas.Count is not 0)
            {
                foreach (var pasta in orderDto.Pastas)
                {
                    totalPrice += pasta.Price ?? 0;

                    if (pasta.ExtraIngredients is not null && pasta.ExtraIngredients.Count is not 0) {
                        foreach (var extraIngredient in pasta.ExtraIngredients)
                        {
                            totalPrice += extraIngredient.Price ?? 0;
                        }
                    }
                }
            }
            if(orderDto.Beverages is not null && orderDto.Beverages.Count is not 0)
            {
                foreach (var beverage in orderDto.Beverages)
                {
                    totalPrice += beverage.Price ?? 0;
                }
            }
            return totalPrice;
        }

        public OrderDto GetOrderWithJunction(Guid orderId)
        {
            var junctionList = junctionService.GetByOrderId(orderId);
            var firstJunction = junctionList.FirstOrDefault();

            var order = new OrderDto
            {
                CustomerName = firstJunction.Order.CustomerName,
                CustomerAddress = firstJunction.Order.CustomerAddress
            };

            if(junctionList.Any())
            {
                order.Pastas = junctionList
                    .Where(j => j.PastaId != null)
                    .Select(j => new PastaDto { 

                        Id = j.PastaId.Value,
                        Name = j.Pasta.Name,
                        Description = j.Pasta.Description,
                        ExtraIngredients = j.Pasta.ExtraIngredients,
                        Price = j.Pasta.Price
                    })
                    .ToList();

                order.Beverages = junctionList
                   .Where(j => j.BeverageId != null)
                   .Select(j => new BeverageDto { 
                       Id = j.BeverageId.Value,
                       Name = j.Pasta.Name,
                       Description = j.Pasta.Description,
                       Price = j.Pasta.Price
                   })
                   .ToList();

                var pastaIdList = junctionList
                    .Where(j => j.PastaId != null)
                    .Select(j => j.PastaId.Value)
                    .ToList();

                // Process each unique pasta ID
                order.Pastas = pastaIdList.Select(pastaId =>
                {
                    var pastaDto = new PastaDto { Id = pastaId };
                    var extraIngredientIds = junctionList
                        .Where(j => j.PastaId == pastaId && j.ExtraIngredientId != null)
                        .Select(j => j.ExtraIngredientId.Value)
                        .ToList();

                    // Create ExtraIngredientDto list for current pasta
                    pastaDto.ExtraIngredients = extraIngredientIds.Select(extraIngredientId =>
                        new ExtraIngredientDto {Id = extraIngredientId}).ToList();
                    return pastaDto;

                }).ToList();   
            }
            return order;
        }
    }
    }
   

