using AutoMapper;
using PastaOrderSystem.Context;
using PastaOrderSystem.DTO;
using PastaOrderSystem.Service.Base;

namespace PastaOrderSystem.Service.Beverage
{
    public class BeverageService(IMapper mapper, DataContext context) : BaseService<Entity.Beverage, BeverageDto>(mapper, context), IBeverageService
    {
    }
}
