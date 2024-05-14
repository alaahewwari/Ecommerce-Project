using ECommerceAPI.Dtos.Product.Requests;
using ECommerceAPI.Services.ProductServices.Interfaces;

namespace ECommerceAPI.Endpoints
{
    public class ProductEndpoints
    {
        public static async Task<IResult> CreateProduct(IProductService productService, CreateProductRequestDto product)
        {
            var response = await productService.CreateProductAsync(product);
            if (response.IsError)
            {
                return Results.BadRequest("Product not created");
            }
            return Results.Created($"/api/products/{response.Value.Id}", response.Value);
        }
    }
}
