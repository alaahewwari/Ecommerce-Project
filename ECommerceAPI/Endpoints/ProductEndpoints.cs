using ECommerceAPI.Dtos.Product.Requests;
using ECommerceAPI.Services.ProductServices.Interfaces;

namespace ECommerceAPI.Endpoints
{
    public class ProductEndpoints
    {
        public static async Task<IResult> CreateProduct(IProductService productService, ProductRequestDto product)
        {
            var response = await productService.CreateProductAsync(product);
            if (response.IsError)
            {
                return Results.BadRequest(response.Errors);
            }
            return Results.Created($"/api/products/{response.Value.Id}", response.Value);
        }
        public static async Task<IResult> UpdateProduct(IProductService productService, ProductRequestDto product, long id)
        {
            var response = await productService.UpdateProductAsync(product, id);
            if (response.IsError)
            {
                return Results.BadRequest(response.Errors);
            }
            return Results.Ok(response.Value);
        }
public static async Task<IResult> GetProductById (IProductService productService, long id)
        {
            var response = await productService.GetProductByIdAsync(id);
            if (response.IsError)
            {
                return Results.NotFound(response.Errors);
            }
            return Results.Ok(response.Value);
        }
        public static async Task<IResult> GetProducts(IProductService productService)
        {
            var response = await productService.GetProductsAsync();
            if (response.IsError)
            {
                return Results.NotFound(response.Errors);
            }
            return Results.Ok(response.Value);
        }
        public static async Task<IResult> DeleteProduct(IProductService productService, long id)
        {
            var response = await productService.DeleteProductAsync(id);
            if (response.IsError)
            {
                return Results.BadRequest(response.Errors);
            }
            return Results.Ok(response.Value);
        }
    }
}
