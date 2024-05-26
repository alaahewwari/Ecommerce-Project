using AutoMapper;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.Product.Requests;
using ECommerceAPI.Dtos.Product.Responses;

namespace ECommerceAPI.MappingProfiles
{
    public class ProductMappings : Profile
    {
        public ProductMappings()
        {
            CreateMap<ProductRequestDto, Product>().ReverseMap();
            CreateMap<Product,ProductResponseDto>().ReverseMap();
            

        }
    }
}
