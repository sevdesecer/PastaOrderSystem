using WebApi.DTO;
using WebApi.Service.Base;

namespace WebApi.Service.Pasta
{
    public interface IPastaService : IBaseService<Entity.Pasta, PastaDto>
    {
    }
}