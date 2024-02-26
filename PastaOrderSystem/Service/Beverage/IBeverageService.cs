using PastaOrderSystem.DTO;
using PastaOrderSystem.Service.Base;

namespace PastaOrderSystem.Service.Beverage
{
    public interface IBeverageService : IBaseService<Entity.Beverage, BeverageDto>
    {
    }
}
