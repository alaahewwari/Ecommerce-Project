using ECommerceAPI.Common;
using ECommerceAPI.Dtos.Authentication.Requests;
using ECommerceAPI.Dtos.Authentication.Responses;
using ErrorOr;
namespace ECommerceAPI.Services.AuthenticationServices.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ErrorOr<SuccessResponse>> RegisterAsync(RegistrationRequestDto request);
        Task<ErrorOr<SuccessResponse>> ConfirmEmailAsync(string email, string token);
        Task<ErrorOr<LoginResponseDto>> LoginAsync(LoginRequestDto request);
        Task<ErrorOr<LoginResponseDto>> RefreshTokenAsync(string token);
        Task<ErrorOr<SuccessResponse>> ForgotPasswordAsync(string email);
        Task<ErrorOr<SuccessResponse>> ResetPasswordAsync(ResetPasswordRequestDto request);
    }
}
