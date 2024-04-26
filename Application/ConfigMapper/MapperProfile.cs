using Application.Dtos.Category;
using AutoMapper;
using Domain.Entitys;

namespace Application.ConfigMapper
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            CreateMap<Category, CategoryDTO>();
        }
    }
}
