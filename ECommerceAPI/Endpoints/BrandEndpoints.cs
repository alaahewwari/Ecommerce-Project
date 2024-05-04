using ECommerceAPI.Services.BrandServices.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceAPI.Endpoints
{
    public class BrandEndpoints
    {
        public static async Task<IResult> GetBrands(IBrandService brandService)
        {
            var categories = await brandService.GetBrandsAsync();
            if (categories.IsNullOrEmpty())
            {
                return Results.NotFound("No categories found");
            }
            return Results.Ok(categories);
        }
    }
}
