using ECommerceAPI.Data.Models;
namespace ECommerceAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> FindByRefreshTokenAsync(string refreshToken);
        Task<User?> AssignRoleToUserAsync(User user, Role role);
        Task<User?> GetUserByIdAsync(long userId);
        Task<IList<User>> GetAllUsersAsync();
        Task<User?> CreateUserAsync(User user);
        Task<User?> UpdateUserAsync(User updatedUser);
        Task<bool> DeleteUserAsync(long userId);
    }
}
