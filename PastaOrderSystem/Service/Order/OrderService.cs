using AutoMapper;
using PastaOrderSystem.Context;
using PastaOrderSystem.DTO;
using PastaOrderSystem.Service.Base;
using PastaOrderSystem.Service.Pasta;

namespace PastaOrderSystem.Service.Order
{
    public class OrderService(IMapper mapper, DataContext context): BaseService<Entity.Order, OrderDto>(mapper, context), IOrderService
    {
    }
}
