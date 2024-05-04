using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.Product.Responses;

namespace ECommerceAPI.Services.CategoryServices.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseDto>> GetCategoriesAsync();
        
        Task<CategoryResponseDto> GetCategoryByIdAsync(long categoryId);
    }
}
