using AutoMapper;
using PastaOrderSystem.Context;
using PastaOrderSystem.DTO;
using PastaOrderSystem.Service.Base;
using PastaOrderSystem.Service.Junction;

namespace PastaOrderSystem.Service.Order
{
    public class OrderService(IMapper mapper, DataContext context, IJunctionService junctionService) : BaseService<Entity.Order, OrderDto>(mapper, context), IOrderService
    {
        public void AddJunction(OrderDto orderDto)
        {
            var orderId = Guid.NewGuid();
            orderDto.Id = orderId;

            var junctions = new List<JunctionDto>();

            // Loop through each pasta in the order if Pastas is not null
            if (orderDto.Pastas != null)
            {
                foreach (PastaDto pasta in orderDto.Pastas)
                {
                    int pastaCount = junctions.Count(j => j.PastaId == pasta.Id);
                    int pastaNumber = pastaCount > 0 ? pastaCount + 1 : 1;

                    // Loop through each extra ingredient for the pasta if ExtraIngredients is not null
                    if (pasta.ExtraIngredients != null)
                    {
                        foreach (ExtraIngredientDto extraIngredient in pasta.ExtraIngredients)
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
            if (orderDto.Beverages != null)
            {
                foreach (BeverageDto beverage in orderDto.Beverages)
                {
                    var junction = new JunctionDto
                    {
                        OrderId = orderDto.Id,
                        BeverageId = beverage.Id
                    };
                    junctions.Add(junction);
                }
            }

            Add(orderDto, false);
            junctionService.AddRange(junctions, false);
            unitOfWork.SaveChanges();
            
        }      
    }
}


