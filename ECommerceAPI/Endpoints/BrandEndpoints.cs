using ECommerceAPI.Dtos.Brand.Requests;
using ECommerceAPI.Services.BrandServices.Interfaces;

namespace ECommerceAPI.Endpoints
{
    public class BrandEndpoints 
    {
        public static async Task<IResult> CreateBrand(IBrandService brandService, BrandRequestDto brand)
        {
            var response = await brandService.CreateBrandAsync(brand);
            if (response.IsError)
            {
                return Results.BadRequest(response.Errors);
}
            return Results.Created($"/api/brands/{response.Value.Id}", response.Value);
        }
        public static async Task<IResult> UpdateBrand(IBrandService brandService, long id, BrandRequestDto brand)
        {
            var response = await brandService.UpdateBrandAsync(id, brand);
            if (response.IsError)
            {
                return Results.BadRequest(response.Errors);
            }
            return Results.Ok(response.Value);
        }
        public static async Task<IResult> GetBrandById(IBrandService brandService, long id)
        {
            var brand = await brandService.GetBrandByIdAsync(id);
            if (brand.IsError)
            {
                return Results.NotFound(brand.Errors);
            }
            return Results.Ok(brand.Value);
        }
        public static async Task<IResult> GetBrands(IBrandService brandService)
        {
            var brands = await brandService.GetBrandsAsync();
            return Results.Ok(brands);
        }
        public static async Task<IResult> DeleteBrand(IBrandService brandService, long id)
        {
            var response = await brandService.DeleteBrandAsync(id);
            if (response.IsError)
            {
                return Results.BadRequest(response.Errors);
            }
            return Results.Ok(response.Value);
        }
    }
}
