using AutoMapper;
using ECommerceAPI.Common;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.Category.Requests;
using ECommerceAPI.Dtos.Product.Responses;
using ECommerceAPI.ErrorHandling;
using ECommerceAPI.Repositories.Interfaces;
using ECommerceAPI.Services.CategoryServices.Interfaces;
using ErrorOr;


namespace ECommerceAPI.Services.CategoryServices.Implementations
{
    public class CategoryService(
        ICategoryRepository categoryRepository,
        IMapper mapper) : ICategoryService
    {
        public async Task<ErrorOr<CategoryResponseDto>> CreateCategoryAsync(CategoryRequestDto categoryDto)
        {       
                var existCategory = await categoryRepository.GetCategoryByNameAsync(categoryDto.Name);
                if (existCategory != null)
                {
                    return CategoryErrors.CategoryAlreadyExists;
                }
                var category = mapper.Map<Category>(categoryDto);
                var result = await categoryRepository.CreateCategoryAsync(category);
                if (result is null)
                {
                    return CategoryErrors.CategoryCreationFailed;
                }
                var response = mapper.Map<CategoryResponseDto>(result);
                return response;
        }
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
        public async Task<ErrorOr<CategoryResponseDto>> UpdateCategoryAsync(long categoryId, CategoryRequestDto categoryDto)
        {
            var category = await categoryRepository.GetCategoryByIdAsync(categoryId);
            if (category is null)
            {
                return CategoryErrors.CategoryNotFound;
            }
            var updatedCategory = mapper.Map<Category>(categoryDto);
            var result = await categoryRepository.UpdateCategoryAsync(updatedCategory, categoryId);
            var response = mapper.Map<CategoryResponseDto>(updatedCategory);
            if (response is null)
            {
                return CategoryErrors.CategoryUpdateFailed;
            }
            return response;
        }
        public async Task<ErrorOr<SuccessResponse>> DeleteCategoryAsync(long categoryId)
        {
                var category = await categoryRepository.GetCategoryByIdAsync(categoryId);
                if (category is null)
                {
                    return CategoryErrors.CategoryNotFound;
                }
                var result = await categoryRepository.DeleteCategoryAsync(categoryId);
                if (!result)
                {
                    return CategoryErrors.CategoryDeletionFailed;
                }
                return new SuccessResponse("Category deleted successfully");
        }
    }
}
