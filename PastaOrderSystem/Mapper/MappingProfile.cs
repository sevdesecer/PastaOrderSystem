using AutoMapper;
using WebApi.DTO;
using WebApi.Entity;


namespace WebApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Pasta,PastaDto>().ReverseMap();
            CreateMap<Order,OrderDto>().ReverseMap();
            CreateMap<Beverage,BeverageDto>().ReverseMap();
            CreateMap<Junction,JunctionDto>().ReverseMap();
            CreateMap<ExtraIngredient,ExtraIngredientDto>().ReverseMap();
        }
    }
}
