using Application.Dtos;
using Application.Dtos.Product;
using Application.Dtos.Sale.Request;
using Application.Dtos.Sale.Response;
using AutoMapper;
using Domain.Entitys;

namespace Application.ConfigMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDTO>();

            CreateMap<Product, ProductoGetResponse>()
                .ForMember(destination => destination.CategoriaId,
                memberOptions => memberOptions.MapFrom(source => source.categoryId));

            CreateMap<Product, ProductResponse>();

            CreateMap<ProductRequest, Product>().ReverseMap();

            CreateMap<Sale, SaleResponse>().ReverseMap();

            CreateMap<Product, SaleProductResponse>()
                .ForMember(destination => destination.ProductoId,
                memberOptions => memberOptions.MapFrom(source => source.ProductoId.ToString()));


            CreateMap<Sale, SaleResponse>()
           .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.SaleProducts))
           .ReverseMap();

            CreateMap<SaleProduct, SaleProductResponse>()
                .ForMember(dest => dest.SaleId, opt => opt.MapFrom(src => src.SaleId))
                .ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Products.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Products.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Products.Discount))
                .ReverseMap();

            CreateMap<SaleProductRequest, SaleProduct>();
        }


    }
}
