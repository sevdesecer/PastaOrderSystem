using AutoMapper;
using PastaOrderSystem.Context;
using PastaOrderSystem.DTO;
using PastaOrderSystem.Service.Base;
using PastaOrderSystem.Service.Order;

namespace PastaOrderSystem.Service.Junction
{
    public class JunctionService(IMapper mapper, DataContext context) : BaseService<Entity.Junction, JunctionDto>(mapper, context), IJunctionService
    {
    }
}
