using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.Authentication.Responses;
namespace ECommerceAPI.Services.TokenService.Interfaces
{
    public interface ITokenService
    {
         public Task<LoginResponseDto> GenerateTokenAsync(User user);
    }
}
