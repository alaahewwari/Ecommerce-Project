using ECommerceAPI.Data;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repositories.Implementations
{
    public class CategoryRepository(
        ApplicationDbContext context
        )
        : ICategoryRepository
    {
        public async Task<Category?> CreateCategoryAsync(Category? category)
        {
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return category;
        }
        public async Task<Category?> UpdateCategoryAsync(Category updatedCategory, long categoryId)
        {
            var category = await GetCategoryByIdAsync(categoryId);
            category.Name = updatedCategory.Name;
            context.Categories.Update(category);
            await context.SaveChangesAsync();
            return category;
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var categories = await context.Categories.AsNoTracking().ToListAsync();
            return categories;
        }
        public async Task<Category?> GetCategoryByIdAsync(long categoryId)
        {
            var category = await context.Categories
                .AsNoTracking()
                .Where(b => b.Id == categoryId)
                .FirstOrDefaultAsync();
            return category;
        }
        public async Task<Category?> GetCategoryByNameAsync(string categoryName)
        {
            var category = await context.Categories
                .Where(b => b.Name == categoryName)
                .FirstOrDefaultAsync();
            return category;
        }
        public async Task<bool> DeleteCategoryAsync(long categoryId)
        {
            var category = await GetCategoryByIdAsync(categoryId);
            if (category is null)
            {
                return false;
            }
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
