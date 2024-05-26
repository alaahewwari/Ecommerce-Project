

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

namespace ECommerceAPI.Tests.Endpoints
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
            public async Task GetCategories_ShouldReturnOkResult_WithListOfCategories()
            {
                var categories = _fixture.CreateMany<CategoryResponseDto>(10).ToList();
                _mockCategoryService.Setup(service => service.GetCategoriesAsync()).ReturnsAsync(categories);

                var result = await CategoryEndpoints.GetCategories(_mockCategoryService.Object);

                var okResult = result.Should().BeOfType<Ok<IEnumerable<CategoryResponseDto>>>().Subject;
                okResult.Value.Should().BeEquivalentTo(categories);
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
            public async Task GetCategoryById_ShouldReturnOkResult_WhenCategoryFound()
            {
                var category = _fixture.Create<CategoryResponseDto>();
                ErrorOr<CategoryResponseDto> success = category;
                _mockCategoryService.Setup(service => service.GetCategoryByIdAsync(It.IsAny<long>())).ReturnsAsync(success);

                var result = await CategoryEndpoints.GetCategoryById(_mockCategoryService.Object, 1);

                var okResult = result.Should().BeOfType<Ok<CategoryResponseDto>>().Subject;
                okResult.Value.Should().BeEquivalentTo(category);
            }

            [Fact]
            public async Task CreateCategory_ShouldReturnBadRequest_WhenCategoryNotCreated()
            {
                var createCategoryRequest = _fixture.Create<CreateCategoryRequestDto>();
                var error = CategoryErrors.CategoryCreationFailed;
                _mockCategoryService.Setup(service => service.CreateCategoryAsync(createCategoryRequest)).ReturnsAsync(error);

                var result = await CategoryEndpoints.CreateCategory(_mockCategoryService.Object, createCategoryRequest);

                var badRequestResult = result.Should().BeOfType<BadRequest<string>>().Subject;
                badRequestResult.Value.Should().Be("Category not created");
            }

            [Fact]
            public async Task CreateCategory_ShouldReturnCreatedResult_WithCategory()
            {
                var createCategoryRequest = _fixture.Create<CreateCategoryRequestDto>();
                var category = _fixture.Create<CategoryResponseDto>();

                ErrorOr<CategoryResponseDto> success = category;
                _mockCategoryService.Setup(service => service.CreateCategoryAsync(createCategoryRequest)).ReturnsAsync(success);

                var result = await CategoryEndpoints.CreateCategory(_mockCategoryService.Object, createCategoryRequest);

                var createdResult = result.Should().BeOfType<Created<CategoryResponseDto>>().Subject;
                createdResult.Location.Should().Be($"/api/categories/{category.Id}");
                createdResult.Value.Should().BeEquivalentTo(category);
            }
        }
    
}
