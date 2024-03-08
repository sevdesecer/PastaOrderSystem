using WebApi.DTO;
using WebApi.Service.Base;

namespace WebApi.Service.Order
{
    public interface IOrderService : IBaseService<Entity.Order, OrderDto>
    {
        Task AddJunction(OrderDto model);
    }
}
