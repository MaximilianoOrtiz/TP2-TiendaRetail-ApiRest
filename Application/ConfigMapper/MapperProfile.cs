﻿using Application.Dtos;
using Application.Dtos.Product;
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
        }
    }
}
