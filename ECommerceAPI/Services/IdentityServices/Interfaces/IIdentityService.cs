using ECommerceAPI.Data.Models;

namespace ECommerceAPI.Services.IdentityServices.Interfaces
{
    public interface IIdentityService
    {
        Task<User?> FindByIdAsync(long userId);
        Task<User?> FindByEmailAsync(string email);
        Task<bool> CreateAsync(User user, string password);
        Task<bool> AddToRoleAsync(User user, string role);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<Role?> GetRoleAsync(User user);
        Task<Role?> GetRoleByNameAsync(string roleName);
        Task<bool> ResetPasswordAsync(User user, string token, string newPassword);
        Task<bool> ChangePasswordAsync(User user, string currentPassword, string newPassword);
        Task<bool> RoleExistsAsync(string role);
        Task<string> GenerateEmailConfirmationTokenAsync(User user);
        Task<string> GeneratePasswordResetTokenAsync(User user);
        Task<bool> ConfirmEmailAsync(User user, string token);
        Task<bool> IsEmailConfirmedAsync(User user); 
        Task UpdateAsync(User user);
    }
}
