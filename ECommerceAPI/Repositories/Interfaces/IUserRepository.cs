using ECommerceAPI.Data.Models;

namespace ECommerceAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> FindByRefreshTokenAsync(string refreshToken);
    }
}
