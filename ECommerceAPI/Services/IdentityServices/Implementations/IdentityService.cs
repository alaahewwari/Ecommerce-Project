using ECommerceAPI.Data.Models;
using ECommerceAPI.Services.IdentityServices.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Net;
namespace ECommerceAPI.Services.IdentityServices.Implementations
{
    public class IdentityService(
        UserManager<User> userManager,
        RoleManager<Role> roleManager)
        : IIdentityService
    {
        public async Task<User?> FindByIdAsync(long userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            return user;
        }
        public async Task<User?> FindByEmailAsync(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            return user;
        }
        public async Task<bool> CreateAsync(User user, string password)
        {
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> AddToRoleAsync(User user, string role)
        {
            var result = await userManager.AddToRoleAsync(user, role);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            var result =await userManager.CheckPasswordAsync(user, password);
            return result;
        }
        public async Task<Role?> GetRoleAsync(User user)
        {
            var role = user.RoleId != null ?await roleManager.FindByIdAsync(user.RoleId.ToString()!) : null;
            return role;
        }
        public async Task<Role?> GetRoleByNameAsync(string roleName)
        {
            var role =await roleManager.FindByNameAsync(roleName);
            return role;
        }
        public async Task<bool> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            var result =await userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> RoleExistsAsync(string roleName)
        {
            var result =await roleManager.RoleExistsAsync(roleName);
            return result;
        }
        public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            var token =await userManager.GenerateEmailConfirmationTokenAsync(user);
            return token;
        }
        public async Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            var token =await userManager.GeneratePasswordResetTokenAsync(user);
            return token;
        }
        public async Task<bool> ConfirmEmailAsync(User user, string token)
        {
            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> ResetPasswordAsync(User user, string token, string newPassword)
        {
            var decodedToken = WebUtility.UrlDecode(token);
            var result = await userManager.ResetPasswordAsync(user, token, newPassword);
            return result.Succeeded;
        }
        public async Task<bool> IsEmailConfirmedAsync(User user)
        {
            var result = await userManager.IsEmailConfirmedAsync(user);
            return result;
        }
        public Task UpdateAsync(User user)
        {
            return userManager.UpdateAsync(user);
        }
    }
}
