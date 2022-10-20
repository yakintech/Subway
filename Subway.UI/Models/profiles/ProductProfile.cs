using System;
using AutoMapper;
using Subway.UI.Models.dto;

namespace Subway.UI.Models.profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .AfterMap((_, dest) =>
                 {
                     dest.CreateDAte = DateTime.Now;
                 });

           

        }
    }
}

