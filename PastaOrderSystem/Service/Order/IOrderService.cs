using PastaOrderSystem.DTO;
using PastaOrderSystem.Service.Base;

namespace PastaOrderSystem.Service.Order
{
    public interface IOrderService : IBaseService<Entity.Order, OrderDto>
    {
    }
}
