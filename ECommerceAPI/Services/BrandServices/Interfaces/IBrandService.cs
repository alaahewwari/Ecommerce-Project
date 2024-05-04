using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.Product.Responses;

namespace ECommerceAPI.Services.BrandServices.Interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandResponseDto>> GetBrandsAsync();
        Task<BrandResponseDto> GetBrandByIdAsync(long brandId);
    }
}
