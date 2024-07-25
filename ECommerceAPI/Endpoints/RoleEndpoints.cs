using ECommerceAPI.Dtos.Role.Requests;
using ECommerceAPI.Services.RoleServices.Interfaces;
namespace ECommerceAPI.Endpoints
{
    public class RoleEndpoints
    {
        public static async Task<IResult> CreateRole(IRoleService roleService, RoleRequestDto createRoleRequest)
        {
            var response = await roleService.CreateRoleAsync(createRoleRequest);
            if (response.IsError)
            {
                return Results.BadRequest(response.Errors);
            }
            return Results.Ok(response.Value);
        }
        public static async Task<IResult> GetRoles(IRoleService roleService)
        {
            var response = await roleService.GetRolesAsync();
            return Results.Ok(response);
        }
        public static async Task<IResult> GetRoleById(IRoleService roleService, long id)
        {
            var response = await roleService.GetRoleByIdAsync(id);
            if (response.IsError)
            {
                return Results.BadRequest(response.Errors);
            }
            return Results.Ok(response.Value);
        }
        public static async Task<IResult> UpdateRole(IRoleService roleService, RoleRequestDto updateRoleRequest,long id)
        {
            var response = await roleService.UpdateRoleAsync(id,updateRoleRequest);
            if (response.IsError)
            {
                return Results.BadRequest(response.Errors);
            }
            return Results.Ok(response.Value);
        }
        public static async Task<IResult> DeleteRole(IRoleService roleService, long id)
        {
            var response = await roleService.DeleteRoleAsync(id);
            if (response.IsError)
            {
                return Results.BadRequest(response.Errors);
            }
            return Results.Ok(response.Value);
        }
    }
}
