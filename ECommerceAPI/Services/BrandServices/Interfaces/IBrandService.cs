using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.Product.Responses;
using ErrorOr;

namespace ECommerceAPI.Services.BrandServices.Interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandResponseDto>> GetBrandsAsync();
        Task<ErrorOr<BrandResponseDto>> GetBrandByIdAsync(long brandId);
    }
}
