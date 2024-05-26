using ECommerceAPI.Services.BrandServices.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceAPI.Endpoints
{
    public class BrandEndpoints
    {
        public static async Task<IResult> GetBrands(IBrandService brandService)
        {
            var brands = await brandService.GetBrandsAsync();
            return Results.Ok(brands);
        }
        public static async Task<IResult> GetBrandById(IBrandService brandService, int id)
        {
            var brand = await brandService.GetBrandByIdAsync(id);
            if (brand.IsError)
            {
                return Results.NotFound(brand.Errors);
            }
            return Results.Ok(brand.Value);
        }

    }
}
