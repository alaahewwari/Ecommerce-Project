using AutoFixture;
using ECommerceAPI.Common;
using ECommerceAPI.Dtos.Role.Requests;
using ECommerceAPI.Dtos.Role.Responses;
using ECommerceAPI.Endpoints;
using ECommerceAPI.ErrorHandling.RoleErrors;
using ECommerceAPI.Services.RoleServices.Interfaces;
using ErrorOr;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;

namespace ECommerceAPI.Tests.EndpointsTests
{
    public class RoleEndpointsTests
    {
        private readonly Mock<IRoleService> _mockRoleService;
        private readonly Fixture _fixture;
        public RoleEndpointsTests()
        {
            _mockRoleService = new Mock<IRoleService>();
            _fixture = new Fixture();
        }
        [Fact]
        public async Task CreateRole_ShouldReturnSuccessResponse_WithRole()
        {
            var expected = _fixture.Create<RoleResponseDto>();
            _mockRoleService.Setup(service => service.CreateRoleAsync(It.IsAny<RoleRequestDto>())).ReturnsAsync(expected);
            var result = await RoleEndpoints.CreateRole(_mockRoleService.Object, _fixture.Create<RoleRequestDto>());
            var actual = result.Should().BeOfType<Created<RoleResponseDto>>().Subject;
            actual.Location.Should().Be($"/api/roles/{expected.Id}");
            actual.Value.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public async Task CreateRole_ShouldReturnBadRequest_WhenRoleNotCreated()
        {
            var error = RoleErrors.RoleCreationFailed;
            _mockRoleService.Setup(service => service.CreateRoleAsync(It.IsAny<RoleRequestDto>())).ReturnsAsync(error);
            var result = await RoleEndpoints.CreateRole(_mockRoleService.Object, _fixture.Create<RoleRequestDto>());
            var actual = result.Should().BeOfType<BadRequest<List<Error>>>().Subject;
            actual.Value.Should().Contain(error);
        }
        [Fact]
        public async Task UpdateRole_ShouldReturnSuccessResponse_WithUpdatedRole()
        {
            var roleId = _fixture.Create<long>();
            var role = _fixture.Create<RoleRequestDto>();
            var expected = _fixture.Create<RoleResponseDto>();
            ErrorOr<RoleResponseDto> success = expected;
            _mockRoleService.Setup(service => service.UpdateRoleAsync(roleId, role)).ReturnsAsync(success);

            var result = await RoleEndpoints.UpdateRole(_mockRoleService.Object,role, roleId);

            var actual = result.Should().BeOfType<Ok<RoleResponseDto>>().Subject;
            actual.Value.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public async Task UpdateRole_ShouldReturnBadRequest_WhenRoleNotUpdated()
        {
            var roleId = _fixture.Create<long>();
            var role = _fixture.Create<RoleRequestDto>();
            var expected = RoleErrors.RoleUpdateFailed;
            _mockRoleService.Setup(service => service.UpdateRoleAsync(roleId, role)).ReturnsAsync(expected);

            var result = await RoleEndpoints.UpdateRole(_mockRoleService.Object, role, roleId);
            var actual = result.Should().BeOfType<BadRequest<List<Error>>>().Subject;
            actual.Value.Should().Contain(expected);
        }
        [Fact]
        public async Task DeleteRole_ShouldReturnSuccessResponse_WhenRoleDeleted()
        {
            var roleId = _fixture.Create<long>();
            var expected = new SuccessResponse("Role deleted successfully");
            ErrorOr<SuccessResponse> success = expected;
            _mockRoleService.Setup(service => service.DeleteRoleAsync(roleId)).ReturnsAsync(success);
            var result = await RoleEndpoints.DeleteRole(_mockRoleService.Object, roleId);
            var actual = result.Should().BeOfType<Ok<SuccessResponse>>().Subject;
            actual.Value.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public async Task DeleteRole_ShouldReturnBadRequest_WhenRoleDeletionFailed()
        {
            var roleId = _fixture.Create<long>();
            var expected = RoleErrors.RoleDeletionFailed;
            _mockRoleService.Setup(service => service.DeleteRoleAsync(roleId)).ReturnsAsync(expected);
            var result = await RoleEndpoints.DeleteRole(_mockRoleService.Object, roleId);
            var actual = result.Should().BeOfType<BadRequest<List<Error>>>().Subject;
            actual.Value.Should().Contain(expected);
        }
    }
}
