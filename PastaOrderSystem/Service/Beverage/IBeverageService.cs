using WebApi.DTO;
using WebApi.Service.Base;

namespace WebApi.Service.Beverage
{
    public interface IBeverageService : IBaseService<Entity.Beverage, BeverageDto>
    {
    }
}
