using WebApi.DTO;
using WebApi.Service.Base;

namespace WebApi.Service.Junction
{
    public interface IJunctionService : IBaseService<Entity.Junction, JunctionDto>
    {
        IEnumerable<JunctionDto> GetByOrderId(Guid orderId);
    }
}
