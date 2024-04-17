using AutoMapper;
using WebApi.Context;
using WebApi.DTO;
using WebApi.Service.Base;

namespace WebApi.Service.Pasta
{
    public class PastaService(IMapper mapper, DataContext context) : BaseService<Entity.Pasta, PastaDto>(mapper, context), IPastaService
    {
    }
}