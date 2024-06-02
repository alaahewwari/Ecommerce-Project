using AutoFixture;
using ECommerceAPI.Dtos.Product.Requests;
using ECommerceAPI.Dtos.Product.Responses;
using ECommerceAPI.Endpoints;
using ECommerceAPI.Services.ProductServices.Interfaces;
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
        public async Task CreateProductAsync_ShouldReturnSuccessResponse_WithProduct()
        {
            var expected = _fixture.Create<ProductResponseDto>();
            _mockProductService.Setup(service => service.CreateProductAsync(It.IsAny<ProductRequestDto>())).ReturnsAsync(expected);

            var result = await ProductEndpoints.CreateProduct(_mockProductService.Object, _fixture.Create<ProductRequestDto>());
            
            var actual = result.Should().BeOfType<Created<ProductResponseDto>>().Subject;
            actual.Location.Should().Be($"/api/products/{expected.Id}");
            actual.Value.Should().BeEquivalentTo(expected);
        }
    }
}
