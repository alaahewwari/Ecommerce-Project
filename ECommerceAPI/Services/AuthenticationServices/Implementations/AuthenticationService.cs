using ECommerceAPI.Common;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.Authentication.Requests;
using ECommerceAPI.ErrorHandling;
using ECommerceAPI.Services.AuthenticationServices.Interfaces;
using ECommerceAPI.Services.EmailServices.Interfaces;
using ECommerceAPI.Services.IdentityServices.Interfaces;
using ECommerceAPI.Utilities.Email;
using ErrorOr;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceAPI.Services.AuthenticationServices.Implementations
{
    public class AuthenticationService(
        IIdentityService identityService,
        IEmailService emailService)
        : IAuthenticationService
    {
        public async Task<ErrorOr<SuccessResponse>> RegisterAsync(RegistrationRequestDto request,string url)
        {
var userExists = await identityService.FindByEmailAsync(request.Email);
            if (userExists is not null)
            {
return IdentityErrors.UserAlreadyExists;
            }

            var applicationUser = new User
            {
                Email = request.Email,
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
            };
            var creationResult = await identityService.CreateAsync(applicationUser, request.Password);
            if (!creationResult)
            {
return IdentityErrors.UserCreationFailed;
            }

            var token = await GenerateAndSendEmailConfirmationEmailAsync(applicationUser,url);
            if (token.IsNullOrEmpty())
            {
                return IdentityErrors.InvalidToken;
            }
            
            return new SuccessResponse("User created successfully. Please check your email to confirm your account.");
        }
        public async Task<ErrorOr<SuccessResponse>> ConfirmEmailAsync(string email, string token)
        {
            var user = await identityService.FindByEmailAsync(email);
            if (user is null)
            {
                return IdentityErrors.UserNotFound;
            }
            var result = await identityService.ConfirmEmailAsync(user, token);
            if (!result)
            {
                return IdentityErrors.InvalidToken;
            }
            return new SuccessResponse("Email confirmed successfully.");
        }
        private async Task<string> GenerateAndSendEmailConfirmationEmailAsync(User user,string baseUrl)
        {
            var token = await identityService.GenerateEmailConfirmationTokenAsync(user);
var confirmationUrl = UrlBuilder.BuildConfirmationUrl(baseUrl, user.Email!, token);
            await emailService.SendConfirmationEmailAsync(user.Email!, confirmationUrl);
            return token;

        }
    }
}
