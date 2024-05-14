using AutoMapper;
using ECommerceAPI.Dtos.Product.Responses;
using ECommerceAPI.ErrorHandling;
using ECommerceAPI.Repositories.Interfaces;
using ECommerceAPI.Services.CategoryServices.Interfaces;
using ErrorOr;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using System.Resources;

namespace ECommerceAPI.Services.CategoryServices.Implementations
{
    public class CategoryService(
        ICategoryRepository categoryRepository,
        IMapper mapper
        ) : ICategoryService
    {
        public async Task<IEnumerable<CategoryResponseDto>> GetCategoriesAsync()
        {
                var categories = await categoryRepository.GetCategoriesAsync();
                var response = mapper.Map<IEnumerable<CategoryResponseDto>>(categories);
                return response;
        }
        public async Task<ErrorOr<CategoryResponseDto>> GetCategoryByIdAsync(long categoryId)
        {
                var category = await categoryRepository.GetCategoryByIdAsync(categoryId);
                if (category is null)
                {
                    return CategoryErrors.CategoryNotFound;
                }
                var response = mapper.Map<CategoryResponseDto>(category);
                return response;
        }


    }
}
