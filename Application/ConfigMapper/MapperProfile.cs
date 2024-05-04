using Application.Dtos;
using Application.Dtos.Product;
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
                .ForMember(destination => destination.categoriaId,
                memberOptions => memberOptions.MapFrom(source => source.categoryId));

            CreateMap<Product, ProductResponse>();

            CreateMap<ProductRequest, Product>();

            CreateMap<Sale, SaleResponse>().ReverseMap();

            CreateMap<Product, SaleProductResponse>()
                .ForMember(destination => destination.ProductoId,
                memberOptions => memberOptions.MapFrom(source => source.ProductoId.ToString()));


        }


    }
}
