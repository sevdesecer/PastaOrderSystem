using AutoMapper;
using WebApi.Context;
using WebApi.DTO;
using WebApi.Service.Base;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Service.Junction
{
    public class JunctionService(IMapper mapper, DataContext dataContext) : BaseService<Entity.Junction, JunctionDto>(mapper, dataContext), IJunctionService
    {
        public IEnumerable<JunctionDto> GetByOrderId(Guid orderId)
        {
            if (orderId != Guid.Empty)
            {
                var junctions = dataContext.Junction
                                    .Include(j => j.Pasta)
                                    .Include(j => j.Beverage)
                                    .Include(j => j.Order)
                                    .Include(j => j.ExtraIngredient)
                                    .Where(j => j.OrderId == orderId)
                                    .ToList();

                return mapper.Map<List<JunctionDto>>(junctions);
            }
            return Enumerable.Empty<JunctionDto>();
        }
    }
}
