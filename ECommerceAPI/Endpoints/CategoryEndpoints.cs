using ECommerceAPI.Services.CategoryServices.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceAPI.Endpoints
{
    public class CategoryEndpoints
    {
        public static async Task<IResult> GetCategories(ICategoryService categoryService)
        {
            var categories = await categoryService.GetCategoriesAsync();
            return Results.Ok(categories);
        }
        public static async Task<IResult> GetCategoryById(ICategoryService categoryService, int id)
        {
            var category = await categoryService.GetCategoryByIdAsync(id);
            if (category.IsError)
            {
                return Results.NotFound(category.Errors);
            }
            return Results.Ok(category.Value);
        }
    }
}
