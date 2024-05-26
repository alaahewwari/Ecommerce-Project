using AutoFixture;
using ECommerceAPI.Dtos.Category.Requests;
using ECommerceAPI.Dtos.Product.Responses;
using ECommerceAPI.Endpoints;
using ECommerceAPI.ErrorHandling;
using ECommerceAPI.Services.CategoryServices.Interfaces;
using ErrorOr;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;

namespace ECommerceAPI.Tests.EndpointsTests
{
        public class CategoryEndpointsTests
        {
        private readonly Mock<ICategoryService> _mockCategoryService;
        private readonly Fixture _fixture;
            public CategoryEndpointsTests()
            {
                _mockCategoryService = new Mock<ICategoryService>();
                _fixture = new Fixture();
            }
        [Fact]
            public async Task GetCategories_ShouldReturnSuccessResponse_WithListOfCategories()
            {
                var expected = _fixture.CreateMany<CategoryResponseDto>(10).ToList();
                _mockCategoryService.Setup(service => service.GetCategoriesAsync()).ReturnsAsync(expected);

                var result = await CategoryEndpoints.GetCategories(_mockCategoryService.Object);

                var actual = result.Should().BeOfType<Ok<IEnumerable<CategoryResponseDto>>>().Subject;
                actual.Value.Should().BeEquivalentTo(expected);
            }

            [Fact]
            public async Task GetCategoryById_ShouldReturnNotFound_WhenCategoryNotFound()
            {
                var error = CategoryErrors.CategoryNotFound;
                _mockCategoryService.Setup(service => service.GetCategoryByIdAsync(It.IsAny<long>())).ReturnsAsync(error);

                var result = await CategoryEndpoints.GetCategoryById(_mockCategoryService.Object, 1);

                var notFoundResult = result.Should().BeOfType<NotFound<List<Error>>>().Subject;
                notFoundResult.Value.Should().Contain(error);
            }

            [Fact]
            public async Task GetCategoryById_ShouldReturnSuccessResponse_WhenCategoryFound()
            {
                var category = _fixture.Create<CategoryResponseDto>();
                ErrorOr<CategoryResponseDto> success = category;
                _mockCategoryService.Setup(service => service.GetCategoryByIdAsync(It.IsAny<long>())).ReturnsAsync(success);

                var result = await CategoryEndpoints.GetCategoryById(_mockCategoryService.Object, 1);

                var okResult = result.Should().BeOfType<Ok<CategoryResponseDto>>().Subject;
                okResult.Value.Should().BeEquivalentTo(category);
            }

            [Fact]
            public async Task CreateCategory_ShouldReturnCreatedResult_WithCategory()
            {
                var createCategoryRequest = _fixture.Create<CategoryRequestDto>();
                var expected = _fixture.Create<CategoryResponseDto>();
                ErrorOr<CategoryResponseDto> success = expected;

                _mockCategoryService.Setup(service => service.CreateCategoryAsync(createCategoryRequest)).ReturnsAsync(success);

                var result = await CategoryEndpoints.CreateCategory(_mockCategoryService.Object, createCategoryRequest);

                var actual = result.Should().BeOfType<Created<CategoryResponseDto>>().Subject;
                actual.Location.Should().Be($"/api/categories/{expected.Id}");
                actual.Value.Should().BeEquivalentTo(expected);
            }

        [Fact]
            public async Task CreateCategory_ShouldReturnBadRequest_WhenCategoryNotCreated()
            {
                var categoryRequestDto = _fixture.Create<CategoryRequestDto>();
            var expected = CategoryErrors.CategoryCreationFailed;
                _mockCategoryService.Setup(service => service.CreateCategoryAsync(categoryRequestDto)).ReturnsAsync(expected);

                var result = await CategoryEndpoints.CreateCategory(_mockCategoryService.Object, categoryRequestDto);

                var actual = result.Should().BeOfType<BadRequest<List<Error>>>().Subject;
                actual.Value.Should().Contain(expected);
            }
        }
    
}
