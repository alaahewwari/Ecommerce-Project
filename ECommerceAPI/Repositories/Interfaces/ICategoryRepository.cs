using ECommerceAPI.Data.Models;

namespace ECommerceAPI.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category?> CreateCategoryAsync(Category? category);
        Task<Category?> UpdateCategoryAsync(Category updatedCategory, long categoryId);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(long categoryId);
        Task<Category?> GetCategoryByNameAsync(string categoryName);
        Task<bool> DeleteCategoryAsync(long categoryId);
    }
}
