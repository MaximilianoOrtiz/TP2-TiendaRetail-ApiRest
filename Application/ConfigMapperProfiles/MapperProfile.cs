using Application.Dtos;
using AutoMapper;
using Domain.Entitys;

namespace Application.ConfigMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDTO>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CategoryId));
        }
    }
}
