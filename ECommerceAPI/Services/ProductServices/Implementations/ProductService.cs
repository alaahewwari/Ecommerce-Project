using AutoMapper;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.Product.Requests;
using ECommerceAPI.Dtos.Product.Responses;
using ECommerceAPI.Repositories.Interfaces;
using ECommerceAPI.Services.BrandServices.Interfaces;
using ECommerceAPI.Services.CategoryServices.Interfaces;
using ECommerceAPI.Services.ProductServices.Interfaces;

namespace ECommerceAPI.Services.ProductService.Implementations
{
    public class ProductService(
        IMapper mapper,
        IProductRepository productRepository,
        IBrandService brandService,
        ICategoryService categoryService
        ) : IProductService
    {
        public async Task<CreateProductResponseDto> CreateProductAsync(CreateProductRequestDto productDto)
        {
           var brand = await brandService.GetBrandByIdAsync(productDto.BrandId);
            if (brand == null)
            {
                throw new Exception("Brand not found");
            }
            var category = await categoryService.GetCategoryByIdAsync(productDto.CategoryId);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            var product = mapper.Map<Product>(productDto);
            
            var result = await productRepository.CreateProductAsync(product);
            if (result == null)
            {
                throw new Exception("Product not created");
            }
            var response = mapper.Map<CreateProductResponseDto>(result);

            return response;

        }

    }
}
