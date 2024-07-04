using AutoMapper;
using ECommerceAPI.Common;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.Product.Requests;
using ECommerceAPI.Dtos.Product.Responses;
using ECommerceAPI.ErrorHandling;
using ECommerceAPI.Repositories.Interfaces;
using ECommerceAPI.Services.AuthenticationServices.Interfaces;
using ECommerceAPI.Services.ProductServices.Interfaces;
using ErrorOr;
namespace ECommerceAPI.Services.ProductServices.Implementations
{
    public class ProductService(
        IMapper mapper,
        IProductRepository productRepository,
        IBrandRepository brandRepository,
        ICategoryRepository categoryRepository,
        IAuthenticatedUserService authenticatedUserService
        ) : IProductService
    {
        public async Task<ErrorOr<ProductResponseDto>> CreateProductAsync(ProductRequestDto productDto)
        {
            var userId = authenticatedUserService.GetAuthenticatedUserIdAsync();
            if (userId == 0)
            {
                return IdentityErrors.Unauthenticated;
            }
            var brand = await brandRepository.GetBrandByIdAsync(productDto.BrandId);
            if (brand is null)
            {
                return BrandErrors.BrandNotFound;
            }
            var category = await categoryRepository.GetCategoryByIdAsync(productDto.CategoryId);
            if (category is null)
            {
                return CategoryErrors.CategoryNotFound;
            }
            var product = mapper.Map<Product>(productDto);
            product.CreatedDate = DateTime.Now;
            product.CreatedUserId = userId;
            var result = await productRepository.CreateProductAsync(product);
            if (result is null)
            {
                return ProductErrors.ProductCreationFailed;
            }
            var response = await GetProductByIdAsync(result.Id);
            return response;
        }
        public async Task<ErrorOr<ProductResponseDto>> UpdateProductAsync(ProductRequestDto productDto, long id)
        {
            var userId = authenticatedUserService.GetAuthenticatedUserIdAsync();
            if (userId == 0)
            {
                return IdentityErrors.Unauthenticated;
            }
            var product = await productRepository.GetProductByIdAsync(id);
            if (product is null)
            {
                return ProductErrors.ProductNotFound;
            }
            var brand = await brandRepository.GetBrandByIdAsync(productDto.BrandId);
            if (brand is null)
            {
                return BrandErrors.BrandNotFound;
            }
            var category = await categoryRepository.GetCategoryByIdAsync(productDto.CategoryId);

            if (category is null)
            {
                return CategoryErrors.CategoryNotFound;
            }
            var updatedProduct = mapper.Map<Product>(productDto);
            updatedProduct.Id = id;
            updatedProduct.UpdatedDate = DateTime.Now;
            updatedProduct.UpdatedUserId = userId;
            var result = await productRepository.UpdateProductAsync(updatedProduct);
            var response = mapper.Map<ProductResponseDto>(result);
            if (response is null)
            {
                return ProductErrors.ProductUpdateFailed;
            }
            return response;
        }
        public async Task<ErrorOr<ProductResponseDto>> GetProductByIdAsync(long id)
        {
            var product = await productRepository.GetProductByIdAsync(id);
            if (product is null)
            {
                return ProductErrors.ProductNotFound;
            }
            var response = mapper.Map<ProductResponseDto>(product);
            return response;
        }
        public async Task<ErrorOr<IList<ProductResponseDto>>> GetProductsAsync()
        {
            var products = await productRepository.GetProductsAsync();
            var response = mapper.Map<IList<ProductResponseDto>>(products);
            return response.ToList();
        }
        public async Task<ErrorOr<SuccessResponse>> DeleteProductAsync(long id)
        {
            var product = await productRepository.GetProductByIdAsync(id);
            if (product is null)
            {
                return ProductErrors.ProductNotFound;
            }
            var result = await productRepository.DeleteProductAsync(id);
            if (!result)
            {
                return ProductErrors.ProductDeletionFailed;
            }
            return new SuccessResponse("Product deleted successfully");
        }
    }
}