using ECommerceAPI.Dtos.Product.Responses;
using ErrorOr;

namespace ECommerceAPI.Services.CategoryServices.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseDto>> GetCategoriesAsync();
        Task<ErrorOr<CategoryResponseDto>> GetCategoryByIdAsync(long categoryId);
    }
}
