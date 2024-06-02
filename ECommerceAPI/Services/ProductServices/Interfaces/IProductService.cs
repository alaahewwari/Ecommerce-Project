using ECommerceAPI.Common;
using ECommerceAPI.Dtos.Product.Requests;
using ECommerceAPI.Dtos.Product.Responses;
using ErrorOr;

namespace ECommerceAPI.Services.ProductServices.Interfaces
{
    public interface IProductService
    {
        Task<ErrorOr<ProductResponseDto>> CreateProductAsync(ProductRequestDto product);
        Task<ErrorOr<ProductResponseDto>> UpdateProductAsync(ProductRequestDto product, long id);
        Task<ErrorOr<ProductResponseDto>> GetProductByIdAsync(long id);
        Task<ErrorOr<IList<ProductResponseDto>>> GetProductsAsync(); 
        Task<ErrorOr<SuccessResponse>> DeleteProductAsync(long id);
    }
}
