using ECommerceAPI.Dtos.Category.Requests;
using ECommerceAPI.Services.CategoryServices.Interfaces;
namespace ECommerceAPI.Endpoints;

public class CategoryEndpoints 
{
    public static async Task<IResult> CreateCategory(ICategoryService categoryService, CategoryRequestDto category)
    {
        var response = await categoryService.CreateCategoryAsync(category);
        if (response.IsError)
        {
            return Results.BadRequest(response.Errors);
        }
        return Results.Created($"/api/categories/{response.Value.Id}", response.Value);
    }

    public static async Task<IResult> UpdateCategory(ICategoryService categoryService, long id, CategoryRequestDto category)
    {
        var response = await categoryService.UpdateCategoryAsync(id, category);
        if (response.IsError)
        {
            return Results.BadRequest(response.Errors);
        }
        return Results.Ok(response.Value);
    }

    public static async Task<IResult> GetCategories(ICategoryService categoryService)
    {
        var categories = await categoryService.GetCategoriesAsync();
        return Results.Ok(categories);
    }

    public static async Task<IResult> GetCategoryById(ICategoryService categoryService, long id)
    {
        var category = await categoryService.GetCategoryByIdAsync(id);
        if (category.IsError)
        {
            return Results.NotFound(category.Errors);
        }
        return Results.Ok(category.Value);
    }

    public static async Task<IResult> DeleteCategory(ICategoryService categoryService, long id)
    {
        var response = await categoryService.DeleteCategoryAsync(id);
        if (response.IsError)
        {
            return Results.BadRequest(response.Errors);
        }
        return Results.Ok(response.Value);
    }
}