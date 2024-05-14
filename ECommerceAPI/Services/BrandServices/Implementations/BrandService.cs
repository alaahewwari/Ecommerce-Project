using AutoMapper;
using ECommerceAPI.Dtos.Product.Responses;
using ECommerceAPI.ErrorHandling;
using ECommerceAPI.Repositories.Interfaces;
using ECommerceAPI.Services.BrandServices.Interfaces;
using ErrorOr;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceAPI.Services.BrandServices.Implementations
{
    public class BrandService(
        IBrandRepository brandRepository,
        IMapper mapper
        ) : IBrandService
    {

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


    }
}
