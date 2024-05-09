using Application.Dtos;
using Application.Dtos.Product.Response;
using AutoMapper;
using Domain.Entitys;

namespace Application.ConfigMapperProfiles
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductoGetResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.CategoriaName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Product, ProductResponse>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId));

            CreateMap<ProductRequest, Product>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Category, opt => opt.Ignore());
        }
    }
}
