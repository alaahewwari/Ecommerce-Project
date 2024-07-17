
using AutoFixture;
using ECommerceAPI.Common;
using ECommerceAPI.Dtos.Authentication.Requests;
using ECommerceAPI.Endpoints;
using ECommerceAPI.ErrorHandling.IdentityErrors;
using ECommerceAPI.Services.AuthenticationServices.Interfaces;
using ErrorOr;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
namespace ECommerceAPI.Tests.EndpointsTests
{
    //move to folders 
    public class AuthenticationTests
    {
        private readonly Mock<IAuthenticationService> _mockAuthenticationService;
        private readonly Fixture _fixture;
        public AuthenticationTests()
        {
            _mockAuthenticationService = new Mock<IAuthenticationService>();
            _fixture = new Fixture();
        }
        [Fact]
        public async Task Register_ShouldReturnSuccessResponse_WhenUserCreated()
        {
            var user = _fixture.Create<RegistrationRequestDto>();
            var expected = new SuccessResponse("User created successfully, check your email");
            ErrorOr<SuccessResponse> success = expected;
            _mockAuthenticationService.Setup(service => service.RegisterAsync(user)).ReturnsAsync(success);
            var result = await AuthenticationEndpoints.Register(_mockAuthenticationService.Object, user);
            var actual = result.Should().BeOfType<Ok<SuccessResponse>>().Subject;
            actual.Value.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public async Task Register_ShouldReturnBadRequest_WhenUserNotCreated()
        {
            var user = _fixture.Create<RegistrationRequestDto>();
            var error = IdentityErrors.UserCreationFailed;
            ErrorOr<SuccessResponse> failure = error;
            _mockAuthenticationService.Setup(service => service.RegisterAsync(user)).ReturnsAsync(failure);
            var result = await AuthenticationEndpoints.Register(_mockAuthenticationService.Object, user);
            var actual = result.Should().BeOfType<BadRequest<Error>>().Subject;
            actual.Value.Should().BeEquivalentTo(error);
        }
    }
}