using AutoMapper;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.Product.Responses;
using ECommerceAPI.Repositories.Interfaces;
using ECommerceAPI.Services.BrandServices.Interfaces;
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
            if (brands.IsNullOrEmpty())
            {
                throw new Exception("No brands found");
            }
            var response = mapper.Map<IEnumerable<BrandResponseDto>>(brands);
            return response;
        }

        public async Task<BrandResponseDto> GetBrandByIdAsync(long brandId)
        {
            var brand = await brandRepository.GetBrandByIdAsync(brandId);
            if (brand == null)
            {
                throw new Exception("Brand not found");
            }
            var response = mapper.Map<BrandResponseDto>(brand);
            return response;
        }


    }
}
