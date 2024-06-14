using Application.Dtos.Sale.Response;
using AutoMapper;
using Domain.Entitys;

namespace Application.ConfigMapperProfiles
{
    public class SaleProductMapper : Profile
    {
        public SaleProductMapper()
        {
            CreateMap<Product, SaleProductResponse>()
               .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
               .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            CreateMap<SaleProduct, SaleProductResponse>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ShoppingCartId))
               .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
               .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
               .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
               .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
               .ReverseMap();

            CreateMap<Product, SaleProduct>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount));
        }
    }
}
