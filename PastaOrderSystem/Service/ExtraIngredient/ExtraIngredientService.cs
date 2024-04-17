using AutoMapper;
using WebApi.Context;
using WebApi.DTO;
using WebApi.Service.Base;

namespace WebApi.Service.ExtraIngredient
{
    public class ExtraIngredientService(IMapper mapper, DataContext context) : BaseService<Entity.ExtraIngredient, ExtraIngredientDto>(mapper, context), IExtraIngredientService
    {
    }
}