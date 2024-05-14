using ECommerceAPI.Dtos.Product.Requests;
using ECommerceAPI.Dtos.Product.Responses;
using ErrorOr;

namespace ECommerceAPI.Services.ProductServices.Interfaces
{
    public interface IProductService
    {
        Task<ErrorOr<CreateProductResponseDto>> CreateProductAsync(CreateProductRequestDto product);
        
    }
}
