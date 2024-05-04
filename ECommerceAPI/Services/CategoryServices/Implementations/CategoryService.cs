using AutoMapper;
using ECommerceAPI.Dtos.Product.Responses;
using ECommerceAPI.Repositories.Interfaces;
using ECommerceAPI.Services.CategoryServices.Interfaces;
using Microsoft.IdentityModel.Tokens;

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
            if (categories.IsNullOrEmpty())
            {
                throw new Exception("No categories found");
            }
            var response = mapper.Map<IEnumerable<CategoryResponseDto>>(categories);
            return response;
        }
        public async Task<CategoryResponseDto> GetCategoryByIdAsync(long categoryId)
        {
            var category = await categoryRepository.GetCategoryByIdAsync(categoryId);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            var response = mapper.Map<CategoryResponseDto>(category);
            return response;
        }


    }
}
