using AutoMapper;
using ECommerceAPI.Common;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.Brand.Requests;
using ECommerceAPI.Dtos.Product.Responses;
using ECommerceAPI.ErrorHandling;
using ECommerceAPI.Repositories.Interfaces;
using ECommerceAPI.Services.BrandServices.Interfaces;
using ErrorOr;

namespace ECommerceAPI.Services.BrandServices.Implementations
{
    public class BrandService(
        IBrandRepository brandRepository,
        IMapper mapper): IBrandService
    {
        public async Task<ErrorOr<BrandResponseDto>> CreateBrandAsync(BrandRequestDto brandDto)
        {
                var existBrand = await brandRepository.GetBrandByNameAsync(brandDto.Name);
                if (existBrand is not null)
                {
                    return BrandErrors.BrandAlreadyExists;
                }
                var brand = mapper.Map<Brand>(brandDto);
                var result = await brandRepository.CreateBrandAsync(brand);
                if (result is null)
                {
                    return BrandErrors.BrandCreationFailed;
                }
                var response = mapper.Map<BrandResponseDto>(result);
                return response;
        }
        public async Task<ErrorOr<BrandResponseDto>> UpdateBrandAsync(long brandId, BrandRequestDto brandDto)
        {
                var brand = await brandRepository.GetBrandByIdAsync(brandId);
                if (brand is null)
                {
                    return BrandErrors.BrandNotFound;
                }
                var updatedBrand = mapper.Map<Brand>(brandDto);
                var result = await brandRepository.UpdateBrandAsync(updatedBrand,brandId);
            var response = mapper.Map<BrandResponseDto>(result);
                if (response is null )
                {
                    return BrandErrors.BrandUpdateFailed;
                }
                return response;
        }
        public async Task<IEnumerable<BrandResponseDto>> GetBrandsAsync()
        {
                var brands = await brandRepository.GetBrandsAsync();
                var response = mapper.Map<IEnumerable<BrandResponseDto>>(brands);
                return response;
            
        }
        public async Task<ErrorOr<BrandResponseDto>> GetBrandByIdAsync(long brandId)
        {
                var brand = await brandRepository.GetBrandByIdAsync(brandId);
                if (brand is null)
                {
                    return BrandErrors.BrandNotFound;
                }
                var response = mapper.Map<BrandResponseDto>(brand);
                return response;
        }
        public async Task<ErrorOr<SuccessResponse>> DeleteBrandAsync(long brandId)
        {
            var brand = await brandRepository.GetBrandByIdAsync(brandId);
            if (brand is null)
            {
                   return BrandErrors.BrandNotFound;
            }
            var result = await brandRepository.DeleteBrandAsync(brandId);
            if (!result)
            {
                    return BrandErrors.BrandDeletionFailed;
            }
            return new SuccessResponse ( "Brand deleted successfully" );
        }
    }
}
