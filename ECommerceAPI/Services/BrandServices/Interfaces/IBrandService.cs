using ECommerceAPI.Common;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.Brand.Requests;
using ECommerceAPI.Dtos.Product.Responses;
using ErrorOr;

namespace ECommerceAPI.Services.BrandServices.Interfaces
{
    public interface IBrandService
    {
        Task<ErrorOr<BrandResponseDto>> CreateBrandAsync(BrandRequestDto brandDto);
        Task<ErrorOr<BrandResponseDto>> UpdateBrandAsync(long brandId, BrandRequestDto brandDto);
        Task<IEnumerable<BrandResponseDto>> GetBrandsAsync();
        Task<ErrorOr<BrandResponseDto>> GetBrandByIdAsync(long brandId);
        Task<ErrorOr<SuccessResponse>> DeleteBrandAsync(long brandId);

    }
}
