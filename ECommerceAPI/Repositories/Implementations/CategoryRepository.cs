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

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await context.Categories.ToListAsync();
        }
        public async Task<Category?> GetCategoryByIdAsync(long CategoryId)
        {
            var category = await context.Categories
                .Where(c => c.Id == CategoryId)
                .FirstOrDefaultAsync();
            return category;
        }
    }
}
