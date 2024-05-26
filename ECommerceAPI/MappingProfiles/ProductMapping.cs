using AutoMapper;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.Product.Requests;
using ECommerceAPI.Dtos.Product.Responses;

namespace ECommerceAPI.MappingProfiles
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<CreateProductRequestDto, Product>().ReverseMap();

            CreateMap<Product, CreateProductResponseDto>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<BrandResponseDto, Brand>().ReverseMap();

            CreateMap<CategoryResponseDto, Category>().ReverseMap();
        }
    }
}
