using AutoMapper;
using PastaOrderSystem.Context;
using PastaOrderSystem.DTO;
using PastaOrderSystem.Service.Base;
using PastaOrderSystem.Service.Order;

namespace PastaOrderSystem.Service.ExtraIngredient
{
    public class ExtraIngredientService(IMapper mapper, DataContext context) : BaseService<Entity.ExtraIngredient, ExtraIngredientDto>(mapper, context), IExtraIngredientService
    {
    }
}
