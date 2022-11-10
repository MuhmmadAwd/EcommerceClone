using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
            .ForMember(m => m.productBrand, s => s.MapFrom(x => x.productBrand.Name))
            .ForMember(m => m.productType, s => s.MapFrom(x => x.productType.Name))
            .ForMember(m => m.PictureUrl, s => s.MapFrom<ProductUrlResolver>());
        }
    }
}