

using AutoFixture;
using ECommerceAPI.Dtos.Product.Requests;
using ECommerceAPI.Dtos.Product.Responses;
using ECommerceAPI.Endpoints;
using ECommerceAPI.Services.ProductServices.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;

namespace ECommerceAPI.Tests.Endpoints
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
        public async Task CreateProductAsync_ShouldReturnCreatedResult_WithProduct()
        {
            //Arrange 
            var product = _fixture.Create<CreateProductResponseDto>();
            _mockProductService.Setup(service => service.CreateProductAsync(It.IsAny<CreateProductRequestDto>())).ReturnsAsync(product);

            //Act
            var result = await ProductEndpoints.CreateProduct(_mockProductService.Object, _fixture.Create<CreateProductRequestDto>());
            
            //Assert 
            var createdResult = result.Should().BeOfType<Created<CreateProductResponseDto>>().Subject;
            createdResult.Location.Should().Be($"/api/products/{product.Id}");
            createdResult.Value.Should().BeEquivalentTo(product);
        }
    }
}
