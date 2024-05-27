using ECommerceAPI.Common;
using ECommerceAPI.Dtos.Category.Requests;
using ECommerceAPI.Dtos.Product.Responses;
using ErrorOr;

namespace ECommerceAPI.Services.CategoryServices.Interfaces
{
    public interface ICategoryService
    {
        Task<ErrorOr<CategoryResponseDto>> CreateCategoryAsync(CategoryRequestDto categoryDto);
        Task<IEnumerable<CategoryResponseDto>> GetCategoriesAsync();
        Task<ErrorOr<CategoryResponseDto>> GetCategoryByIdAsync(long categoryId);
        Task<ErrorOr<CategoryResponseDto>> UpdateCategoryAsync(long categoryId, CategoryRequestDto categoryDto);
        Task<ErrorOr<SuccessResponse>> DeleteCategoryAsync(long categoryId);
    }
}
