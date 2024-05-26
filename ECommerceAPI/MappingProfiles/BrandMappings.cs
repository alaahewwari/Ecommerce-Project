using AutoMapper;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.Brand.Requests;
using ECommerceAPI.Dtos.Product.Responses;

namespace ECommerceAPI.MappingProfiles
{
    public class BrandMappings : Profile
    {
        public BrandMappings()
        {
            CreateMap<BrandRequestDto, Brand>().ReverseMap();
            CreateMap<Brand, BrandResponseDto>().ReverseMap();
        }
    }
}
