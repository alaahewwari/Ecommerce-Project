using ECommerceAPI.Data.Models;
using ECommerceAPI.Data;
using ECommerceAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace ECommerceAPI.Repositories.Implementations
{
    public class RoleRepository(
        ApplicationDbContext context)
        : IRoleRepository
    {
        public async Task<Role> CreateRoleAsync(Role role)
        {
            await context.Roles.AddAsync(role);
            await context.SaveChangesAsync();
            return role;
        }

        public async Task<Role?> UpdateRoleAsync(Role updatedRole, long roleId)
        {
            var role = await GetRoleByIdAsync(roleId);
            role.Name = updatedRole.Name;
            context.Roles.Update(role); 
            await context.SaveChangesAsync();
            return role;
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            var brands = await context.Roles.AsNoTracking().ToListAsync();
            return brands;
        }

        public async Task<Role?> GetRoleByIdAsync(long roleId)
        {
            var role = await context.Roles
                .AsNoTracking()
                .Where(b => b.Id == roleId)
                .FirstOrDefaultAsync();
            return role;
        }

        public async Task<Role?> GetRoleByNameAsync(string roleName)
        {
            var role = await context.Roles
                .Where(b => b.Name == roleName)
                .FirstOrDefaultAsync();
            return role;
        }

        public async Task<bool> DeleteRoleAsync(long roleId)
        {
            var role = await GetRoleByIdAsync(roleId);
            if (role is null)
            {
                return false;
            }
            context.Roles.Remove(role);
            await context.SaveChangesAsync();
            return true;
        }
    }
}