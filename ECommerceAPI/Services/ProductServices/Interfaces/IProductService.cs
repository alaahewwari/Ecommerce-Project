using ECommerceAPI.Dtos.Product.Requests;
using ECommerceAPI.Dtos.Product.Responses;

namespace ECommerceAPI.Services.ProductServices.Interfaces
{
    public interface IProductService
    {
        Task<CreateProductResponseDto> CreateProductAsync(CreateProductRequestDto product);
        
    }
}
