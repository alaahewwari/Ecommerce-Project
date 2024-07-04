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
        public async Task<User?> AssignRoleToUserAsync(User user, Role role)
        {
            user.Role=role;
            await context.SaveChangesAsync();
            return user;
        }
        public async Task<User?> GetUserByIdAsync(long userId)
        {
            var user = await context.Users.AsNoTracking()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == userId);
            return user;
        }
        public async Task<IList<User>> GetAllUsersAsync()
        {
            var users = await context.Users.AsNoTracking()
                .Include(u => u.Role)
                .ToListAsync();
            return users;
        }
        public async Task<User?> CreateUserAsync(User user)
        {
            user.EmailConfirmed = true;
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }
        public async Task<User?> UpdateUserAsync(User updatedUser)
        {
            var user =await GetUserByIdAsync(updatedUser.Id);
            user.Email = updatedUser.Email;
            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.PhoneNumber = updatedUser.PhoneNumber;
            user.Role = updatedUser.Role;
            context.Update(user);
            await context.SaveChangesAsync();
            return user;
        }
        public async Task<bool> DeleteUserAsync(long userId)
        {
            var user = await GetUserByIdAsync(userId);
            if (user is null)
            {
                return false;
            }
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }
    }
}