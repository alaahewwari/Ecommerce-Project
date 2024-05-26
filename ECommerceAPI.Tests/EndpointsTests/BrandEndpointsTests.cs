using AutoFixture;
using ECommerceAPI.Dtos.Brand.Requests;
using ECommerceAPI.Dtos.Product.Responses;
using ECommerceAPI.Endpoints;
using ECommerceAPI.ErrorHandling;
using ECommerceAPI.Services.BrandServices.Interfaces;
using ErrorOr;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;

namespace ECommerceAPI.Tests.EndpointsTests
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
        public async Task GetBrands_ShouldReturnSuccess_WithListOfBrands()
        {
            var expected = _fixture.CreateMany<BrandResponseDto>(10).ToList();

            _mockBrandService.Setup(service => service.GetBrandsAsync()).ReturnsAsync(expected);

            var result = await BrandEndpoints.GetBrands(_mockBrandService.Object);

            var actual = result.Should().BeOfType<Ok<IEnumerable<BrandResponseDto>>>().Subject;
            actual.Value.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public async Task GetBrandById_ShouldReturnOkResult_WhenBrandFound()
        {
            var expected = _fixture.Create<BrandResponseDto>();
            ErrorOr<BrandResponseDto> success = expected;
            _mockBrandService.Setup(service => service.GetBrandByIdAsync(It.IsAny<long>())).ReturnsAsync(success);

            var result = await BrandEndpoints.GetBrandById(_mockBrandService.Object, 1);

            var actual = result.Should().BeOfType<Ok<BrandResponseDto>>().Subject;
            actual.Value.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public async Task GetBrandyById_ShouldReturnNotFound_WhenBrandNotFound()
        {
            var expected = CategoryErrors.CategoryNotFound;
            _mockBrandService.Setup(service => service.GetBrandByIdAsync(It.IsAny<long>())).ReturnsAsync(expected);

            var result = await BrandEndpoints.GetBrandById(_mockBrandService.Object, 1);

            var actual = result.Should().BeOfType<NotFound<List<Error>>>().Subject;
            actual.Value.Should().Contain(expected);
        }

        [Fact]
        public async Task CreateBrand_ShouldReturnCreatedResult_WithBrand()
        {
            var brands = _fixture.Create<BrandRequestDto>();
            var expected = _fixture.Create<BrandResponseDto>();
            ErrorOr<BrandResponseDto> success = expected;
            _mockBrandService.Setup(service => service.CreateBrandAsync(brands)).ReturnsAsync(success);
            var result = await BrandEndpoints.CreateBrand(_mockBrandService.Object, brands);
            var actual = result.Should().BeOfType<Created<BrandResponseDto>>().Subject;
            actual.Location.Should().Be($"/api/brands/{expected.Id}");
            actual.Value.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public async Task CreateBrand_ShouldReturnBadRequest_WhenBrandNotCreated()
        {
            var expected = BrandErrors.BrandCreationFailed;
            var createBrandRequest = _fixture.Create<BrandRequestDto>();
            _mockBrandService.Setup(service => service.CreateBrandAsync(createBrandRequest)).ReturnsAsync(expected);

            var result = await BrandEndpoints.CreateBrand(_mockBrandService.Object, createBrandRequest);

            var actual = result.Should().BeOfType<BadRequest<List<Error>>>().Subject;
            actual.Value.Should().Contain(expected);
        }

    }
}