using AutoFixture;
using ECommerceAPI.Common;
using ECommerceAPI.Dtos.Product.Requests;
using ECommerceAPI.Dtos.Product.Responses;
using ECommerceAPI.Endpoints;
using ECommerceAPI.ErrorHandling.ProductErrors;
using ECommerceAPI.Services.ProductServices.Interfaces;
using ErrorOr;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;

namespace ECommerceAPI.Tests.EndpointsTests
{
    public class ProductEndpointsTests
    {
        private readonly Mock<IProductService> _mockProductService; 
        private readonly Fixture _fixture;

        public ProductEndpointsTests()
        {
            _mockProductService = new Mock<IProductService>();
            _fixture = new Fixture();
        }

        [Fact]
        public async Task CreateProduct_ShouldReturnSuccessResponse_WithProduct()
        {
            var expected = _fixture.Create<ProductResponseDto>();
            _mockProductService.Setup(service => service.CreateProductAsync(It.IsAny<ProductRequestDto>())).ReturnsAsync(expected);

            var result = await ProductEndpoints.CreateProduct(_mockProductService.Object, _fixture.Create<ProductRequestDto>());
            var actual = result.Should().BeOfType<Created<ProductResponseDto>>().Subject;
            actual.Location.Should().Be($"/api/products/{expected.Id}");
            actual.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task CreateProduct_ShouldReturnBadRequest_WhenProductNotCreated()
        {
var error = ProductErrors.ProductCreationFailed;
            _mockProductService.Setup(service => service.CreateProductAsync(It.IsAny<ProductRequestDto>())).ReturnsAsync(error);

            var result = await ProductEndpoints.CreateProduct(_mockProductService.Object, _fixture.Create<ProductRequestDto>());
            var actual = result.Should().BeOfType<BadRequest<List<Error>>>().Subject;
            actual.Value.Should().Contain(error);
        }
        [Fact]
        public async Task UpdateProduct_ShouldReturnSuccessResponse_WithUpdatedProduct()
        {
            var productId = _fixture.Create<long>();
            var productRequestDto = _fixture.Create<ProductRequestDto>();
            var expected = _fixture.Create<ProductResponseDto>();
            _mockProductService.Setup(service => service.UpdateProductAsync(It.IsAny<ProductRequestDto>(), It.IsAny<long>())).ReturnsAsync(expected);

            var result = await ProductEndpoints.UpdateProduct(_mockProductService.Object,productRequestDto, productId);
            var actual = result.Should().BeOfType<Ok<ProductResponseDto>>().Subject;
            actual.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task UpdateProduct_ShouldReturnBadRequest_WhenProductUpdateFailed()
        {
            var productId = _fixture.Create<long>();
            var productRequestDto = _fixture.Create<ProductRequestDto>();
            var expected = ProductErrors.ProductUpdateFailed;
            _mockProductService.Setup(service => service.UpdateProductAsync(productRequestDto,productId)).ReturnsAsync(expected);

            var result = await ProductEndpoints.UpdateProduct(_mockProductService.Object, productRequestDto, productId);
            var actual = result.Should().BeOfType<BadRequest<List<Error>>>().Subject;
            actual.Value.Should().Contain(expected);
        }
        [Fact]
        public async Task DeleteProduct_ShouldReturnSuccessResponse_WhenProductDeleted()
        {
            var productId = _fixture.Create<long>();
            var expected = new SuccessResponse("Product deleted successfully");
            _mockProductService.Setup(service => service.DeleteProductAsync(productId)).ReturnsAsync(expected);

            var result = await ProductEndpoints.DeleteProduct(_mockProductService.Object, productId);
            var actual = result.Should().BeOfType<Ok<SuccessResponse>>().Subject;
            actual.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task DeleteProduct_ShouldReturnBadRequest_WhenProductDeletionFailed()
        {
            var productId = _fixture.Create<long>();
            var expected = ProductErrors.ProductDeletionFailed;
            _mockProductService.Setup(service => service.DeleteProductAsync(productId)).ReturnsAsync(expected);

            var result = await ProductEndpoints.DeleteProduct(_mockProductService.Object, productId);

            var actual = result.Should().BeOfType<BadRequest<List<Error>>>().Subject;
            actual.Value.Should().Contain(expected);
        }
    }
}
