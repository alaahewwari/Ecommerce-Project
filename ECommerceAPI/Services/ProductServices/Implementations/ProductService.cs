using AutoMapper;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.Product.Requests;
using ECommerceAPI.Dtos.Product.Responses;
using ECommerceAPI.ErrorHandling;
using ECommerceAPI.Repositories.Interfaces;
using ECommerceAPI.Services.BrandServices.Interfaces;
using ECommerceAPI.Services.CategoryServices.Interfaces;
using ECommerceAPI.Services.ProductServices.Interfaces;
using ErrorOr;
using Microsoft.Extensions.Localization;

namespace ECommerceAPI.Services.ProductService.Implementations
{
    public class ProductService(
        IMapper mapper,
        IProductRepository productRepository,
        IBrandService brandService,
        ICategoryService categoryService
        ) : IProductService
    {
        public async Task<ErrorOr<CreateProductResponseDto>> CreateProductAsync(CreateProductRequestDto productDto)
        {
                var brand = await brandService.GetBrandByIdAsync(productDto.BrandId);
                if (brand.IsError)
                {
                    return BrandErrors.BrandNotFound;
                }
                var category = await categoryService.GetCategoryByIdAsync(productDto.CategoryId);
                if (category.IsError)
                {
                    return CategoryErrors.CategoryNotFound;
                }
                var product = mapper.Map<Product>(productDto);

                var result = await productRepository.CreateProductAsync(product);
                if (result is null)
            {
                return ProductErrors.ProductCreationFailed;
                }

                var response = mapper.Map<CreateProductResponseDto>(result);

                return response;
        }

    }
}
