using AutoMapper;
using WebApi.Context;
using WebApi.DTO;
using WebApi.Service.Base;

namespace WebApi.Service.Beverage
{
    public class BeverageService(IMapper mapper, DataContext context) : BaseService<Entity.Beverage, BeverageDto>(mapper, context), IBeverageService
    {
    }
}