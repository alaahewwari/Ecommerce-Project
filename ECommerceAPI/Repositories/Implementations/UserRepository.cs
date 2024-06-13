using ECommerceAPI.Data;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace ECommerceAPI.Repositories.Implementations
{
    public class UserRepository(
        ApplicationDbContext context)
        : IUserRepository
    {
        public async Task<User?> FindByRefreshTokenAsync(string refreshToken)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            return user;
        }
    }
}
