using Application.Dtos.Sale.Response;
using AutoMapper;
using Domain.Entitys;

namespace Application.ConfigMapperProfiles
{
    public class SaleMapper : Profile
    {
        public SaleMapper()
        {
            CreateMap<Sale, SaleResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SaleId))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.SaleProducts))
                .ReverseMap();

            CreateMap<SaleResponse, Sale>();

            CreateMap<Sale, SaleGetResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SaleId))
                .ForMember(dest => dest.TotalPay, opt => opt.MapFrom(src => src.TotalPay))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.TotalQuantity, opt => opt.Ignore());
        }
    }
}
