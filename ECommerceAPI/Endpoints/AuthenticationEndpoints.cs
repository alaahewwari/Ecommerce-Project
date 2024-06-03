using ECommerceAPI.Constants.Email;
using ECommerceAPI.Dtos.Authentication.Requests;
using ECommerceAPI.Services.AuthenticationServices.Interfaces;

namespace ECommerceAPI.Endpoints
{
    public class AuthenticationEndpoints 
    {
        public static async Task<IResult> Register(IAuthenticationService authenticationService, RegistrationRequestDto registerRequest)
        {
            var baseUrl = "https://localhost:7131/api/auth/email-confirmation";
            var response = await authenticationService.RegisterAsync(registerRequest,baseUrl);
            if (response.IsError)
            {
                return Results.BadRequest(response.Errors);
            }
            return Results.Ok(response.Value);
        }
        public static async Task<IResult> ConfirmEmail(IAuthenticationService authenticationService, string email, string token)
        {
            var response = await authenticationService.ConfirmEmailAsync(email, token);
            if (response.IsError)
            {
                return Results.BadRequest(response.Errors);
            }
            return Results.Ok(response.Value);
        }

    }
}
