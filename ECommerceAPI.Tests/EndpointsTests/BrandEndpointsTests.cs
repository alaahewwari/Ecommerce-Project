using AutoFixture;
using ECommerceAPI.Dtos.Brand.Requests;
using ECommerceAPI.Dtos.Product.Responses;
using ECommerceAPI.Endpoints;
using ECommerceAPI.ErrorHandling;
using ECommerceAPI.Services.BrandServices.Interfaces;
using ECommerceAPI.Services.ProductServices.Interfaces;
using ErrorOr;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;

namespace ECommerceAPI.Tests.Endpoints
{
    public class BrandEndpointsTests
    {
        private readonly Mock<IBrandService> _mockBrandService;
        private readonly Fixture _fixture;
        public BrandEndpointsTests()
        {
            _mockBrandService = new Mock<IBrandService>();
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetBrands_ShouldReturnOkResult_WithListOfBrands()
        {
            var brands = _fixture.CreateMany<BrandResponseDto>(10).ToList();
            _mockBrandService.Setup(service => service.GetBrandsAsync()).ReturnsAsync(brands);

            var result = await BrandEndpoints.GetBrands(_mockBrandService.Object);

            var okResult = result.Should().BeOfType<Ok<IEnumerable<BrandResponseDto>>>().Subject;
            okResult.Value.Should().BeEquivalentTo(brands);
        }
        [Fact]
        public async Task GetBrandById_ShouldReturnOkResult_WhenBrandFound()
        {
            var brand = _fixture.Create<BrandResponseDto>();
            ErrorOr<BrandResponseDto> success = brand;
            _mockBrandService.Setup(service => service.GetBrandByIdAsync(It.IsAny<long>())).ReturnsAsync(success);

            var result = await BrandEndpoints.GetBrandById(_mockBrandService.Object, 1);

            var okResult = result.Should().BeOfType<Ok<BrandResponseDto>>().Subject;
            okResult.Value.Should().BeEquivalentTo(brand);
        }
        [Fact]
        public async Task GetCategoryById_ShouldReturnNotFound_WhenCategoryNotFound()
        {
            var error = CategoryErrors.CategoryNotFound;
            _mockBrandService.Setup(service => service.GetBrandByIdAsync(It.IsAny<long>())).ReturnsAsync(error);

            var result = await BrandEndpoints.GetBrandById(_mockBrandService.Object, 1);

            var notFoundResult = result.Should().BeOfType<NotFound<List<Error>>>().Subject;
            notFoundResult.Value.Should().Contain(error);
        }

        [Fact]
        public async Task CreateBrand_ShouldReturnBadRequest_WhenBrandNotCreated()
        {
            var createBrandRequest = _fixture.Create<CreateBrandRequestDto>();
            var error = BrandErrors.BrandCreationFailed;
            _mockBrandService.Setup(service => service.CreateBrandAsync(createBrandRequest)).ReturnsAsync(error);

            var result = await BrandEndpoints.CreateBrand(_mockBrandService.Object, createBrandRequest);

            var badRequestResult = result.Should().BeOfType<BadRequest<string>>().Subject;
            badRequestResult.Value.Should().Be("Brand not created");
        }

        [Fact]
        public async Task CreateBrand_ShouldReturnCreatedResult_WithBrand()
        {
            var createBrandRequest = _fixture.Create<CreateBrandRequestDto>();
            var brand = _fixture.Create<BrandResponseDto>();
            ErrorOr<BrandResponseDto> success = brand;
            _mockBrandService.Setup(service => service.CreateBrandAsync(createBrandRequest)).ReturnsAsync(success);

            var result = await BrandEndpoints.CreateBrand(_mockBrandService.Object, createBrandRequest);

            var createdResult = result.Should().BeOfType<Created<BrandResponseDto>>().Subject;
            createdResult.Location.Should().Be($"/api/brands/{brand.Id}");
            createdResult.Value.Should().BeEquivalentTo(brand);
        }
    }
}