using ECommerceAPI.Services.CategoryServices.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceAPI.Endpoints
{
    public class CategoryEndpoints
    {
        public static async Task<IResult> GetCategories(ICategoryService categoryService)
        {
            var categories = await categoryService.GetCategoriesAsync();
            if (categories.IsNullOrEmpty())
            {
                return Results.NotFound("No categories found");
            }
            return Results.Ok(categories);
        }
    }
}
