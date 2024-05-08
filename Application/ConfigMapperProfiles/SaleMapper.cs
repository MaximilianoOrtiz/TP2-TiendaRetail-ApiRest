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
        }
    }
}
