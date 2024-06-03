using ECommerceAPI.Common;
using ECommerceAPI.Dtos.Authentication.Requests;
using ErrorOr;

namespace ECommerceAPI.Services.AuthenticationServices.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ErrorOr<SuccessResponse>> RegisterAsync(RegistrationRequestDto request, string url);
        Task<ErrorOr<SuccessResponse>> ConfirmEmailAsync(string email, string token);
    }
}
