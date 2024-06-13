using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.Authentication.Responses;
using ECommerceAPI.Services.IdentityServices.Interfaces;
using ECommerceAPI.Services.TokenService.Interfaces;
using Microsoft.IdentityModel.Tokens;
namespace ECommerceAPI.Services.TokenService.Implementations
{
    public class TokenService(
        IIdentityService identityService,
        IConfiguration configuration
        ) : ITokenService
    {
        public async Task<LoginResponseDto> GenerateTokenAsync(User user)
        {
            var accessToken = GenerateAccessTokenAsync(user);
var accessTokenExpiryTime = DateTime.Now.AddMinutes(Convert.ToDouble(configuration["Jwt:AccessTokenValidityInMinutes"]));
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(Convert.ToDouble(configuration["Jwt:RefreshTokenValidity"]));
            await identityService.UpdateAsync(user);
            return new LoginResponseDto
            {
                AccessToken = accessToken,
                AccessTokenExpiryTime = accessTokenExpiryTime,
                RefreshToken = refreshToken,
                RefreshTokenExpiryTime = user.RefreshTokenExpiryTime
            };
        }
        private string GenerateAccessTokenAsync(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var authClaims = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            });
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(configuration["Jwt:AccessTokenValidationInMinutes"]));

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims:authClaims.Claims,
                expires: expires,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
