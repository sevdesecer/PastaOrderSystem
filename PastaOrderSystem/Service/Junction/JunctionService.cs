using AutoMapper;
using PastaOrderSystem.Context;
using PastaOrderSystem.DTO;
using PastaOrderSystem.Service.Base;

namespace PastaOrderSystem.Service.Junction
{
    public class JunctionService(IMapper mapper, DataContext context) : BaseService<Entity.Junction, JunctionDto>(mapper, context), IJunctionService
    {

    }
}
