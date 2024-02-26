using AutoMapper;
using PastaOrderSystem.Context;
using PastaOrderSystem.DTO;
using PastaOrderSystem.Service.Base;

namespace PastaOrderSystem.Service.Pasta
{
    public class PastaService(IMapper mapper, DataContext context) : BaseService<Entity.Pasta, PastaDto>(mapper, context), IPastaService
    {
    }
}
