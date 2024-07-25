using ECommerceAPI.Data.Models;
namespace ECommerceAPI.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role> CreateRoleAsync(Role role);
        Task<Role?> UpdateRoleAsync(Role updatedRole, long roleId);
        Task<IEnumerable<Role>> GetRolesAsync();
        Task<Role?> GetRoleByIdAsync(long roleId);
        Task<Role?> GetRoleByNameAsync(string name);
        Task<bool> DeleteRoleAsync(long roleId);
    }
}
