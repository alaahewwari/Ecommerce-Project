using AutoMapper;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.Category.Requests;
using ECommerceAPI.Dtos.Product.Responses;

namespace ECommerceAPI.MappingProfiles
{
    public class CategoryMappings : Profile
    {
        public CategoryMappings()
        {
            CreateMap<CategoryRequestDto, Category>().ReverseMap();
            CreateMap<Category, CategoryResponseDto>().ReverseMap();
        }
    }
}
