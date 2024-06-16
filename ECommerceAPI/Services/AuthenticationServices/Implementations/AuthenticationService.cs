using System.Security.Claims;
using ECommerceAPI.Common;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.Authentication.Requests;
using ECommerceAPI.Dtos.Authentication.Responses;
using ECommerceAPI.ErrorHandling;
using ECommerceAPI.Repositories.Interfaces;
using ECommerceAPI.Services.AuthenticationServices.Interfaces;
using ECommerceAPI.Services.EmailServices.Interfaces;
using ECommerceAPI.Services.IdentityServices.Interfaces;
using ECommerceAPI.Services.TokenService.Interfaces;
using ECommerceAPI.Services.UrlBuilder.Interfaces;
using ECommerceAPI.Utilities.Email;
using ErrorOr;
using Microsoft.IdentityModel.Tokens;
namespace ECommerceAPI.Services.AuthenticationServices.Implementations
{
    public class AuthenticationService(
        IIdentityService identityService,
        IUrlBuilder urlBuilder,
        ITokenService tokenService,
        IUserRepository userRepository,
        IAuthenticatedUserService authenticatedUserService,
        IEmailService emailService)
        : IAuthenticationService
    { 
        public async Task<ErrorOr<SuccessResponse>> RegisterAsync(RegistrationRequestDto request)
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
            var baseUrl = urlBuilder.GetEmailConfirmationUrl();
            var token = await GenerateAndSendEmailConfirmationEmailAsync(applicationUser,baseUrl);
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
        public async Task<ErrorOr<LoginResponseDto>> LoginAsync(LoginRequestDto request)
        {
            var user = await identityService.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return IdentityErrors.UserNotFound;
            }
var isConfirmed = await identityService.IsEmailConfirmedAsync(user);
            if (!isConfirmed)
            {
                return IdentityErrors.EmailNotConfirmed;
            }
            var result = await identityService.CheckPasswordAsync(user, request.Password);
            if (!result)
            {
                return IdentityErrors.InvalidCredentials;
            } 
            var token = await tokenService.GenerateTokenAsync(user);
            return token;
        }
        public async Task<ErrorOr<LoginResponseDto>> RefreshTokenAsync(string refreshToken)
        {
            if (refreshToken.IsNullOrEmpty())
            {
                return IdentityErrors.InvalidToken;
            }
var user = await userRepository.FindByRefreshTokenAsync(refreshToken);
            if (user is null)
            {
                return IdentityErrors.UserNotFound;
            }
            if (user.RefreshTokenExpiryTime < DateTime.UtcNow)
            {
                return IdentityErrors.InvalidToken;
            }
            var result =await tokenService.GenerateTokenAsync(user);
            return result;
        }
        public async Task<ErrorOr<SuccessResponse>> ForgotPasswordAsync(string email)
        {
            var user = await identityService.FindByEmailAsync(email);
            if (user is null)
            {
                return IdentityErrors.UserNotFound;
            }
            var baseUrl = "https://localhost:5001/reset-password";// just for testing
            var token = await GenerateAndSendResetPsswordEmailAsync(user,baseUrl);
            if (token.IsNullOrEmpty())
            {
                return IdentityErrors.InvalidToken;
            }
            return new SuccessResponse("Paswword reset email sent successfully. Please check your email to reset your password.");
        }
        public async Task<ErrorOr<SuccessResponse>> ResetPasswordAsync(ResetPasswordRequestDto request)
        {
            var user = await identityService.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return IdentityErrors.UserNotFound;
            }
            var result = await identityService.ResetPasswordAsync(user, request.Token, request.NewPassword);
            if (!result)
            {
                return IdentityErrors.InvalidToken;
            }
            return new SuccessResponse("Password reset successfully.");
        }
        public async Task<ErrorOr<SuccessResponse>> ChangePasswordAsync(ChangePasswordRequestDto request)
        {
            var userId = authenticatedUserService.GetAuthenticatedUserIdAsync();
            if (userId == 0)
            {
                return IdentityErrors.Unauthenticated;
            }
            var user = await identityService.FindByIdAsync(userId);
            if (user == null)
            {
                return IdentityErrors.UserNotFound;
            }
            var response = await identityService.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (!response)
            {
                return IdentityErrors.ChangePasswordFailed;
            }
            return new SuccessResponse("Password changed successfully");
        }
        private async Task<string> GenerateAndSendEmailConfirmationEmailAsync(User user,string baseUrl)
        {
            var token = await identityService.GenerateEmailConfirmationTokenAsync(user);
            var confirmationUrl = ConfirmationUrlBuilder.BuildConfirmationUrl(baseUrl, user.Email!, token);
            await emailService.SendConfirmationEmailAsync(user.Email!, confirmationUrl);
            return token;
        }
        private async Task<string> GenerateAndSendResetPsswordEmailAsync(User user, string baseUrl)
        {
            var token = await identityService.GeneratePasswordResetTokenAsync(user);
            var confirmationUrl = ConfirmationUrlBuilder.BuildConfirmationUrl(baseUrl, user.Email!, token);
            await emailService.SendResetPasswordEmailAsync(user.Email!, confirmationUrl);
            return token;
        }
    }
}
