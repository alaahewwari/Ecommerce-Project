using AutoMapper;
using ECommerceAPI.Common;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.Role.Requests;
using ECommerceAPI.Dtos.Role.Responses;
using ECommerceAPI.ErrorHandling;
using ECommerceAPI.Repositories.Interfaces;
using ECommerceAPI.Services.RoleServices.Interfaces;
using ErrorOr;
namespace ECommerceAPI.Services.RoleServices.Implementations
{
    public class RoleService(
        IRoleRepository roleRepository,
        IMapper mapper) : IRoleService
    {
        public async Task<ErrorOr<RoleResponseDto>> CreateRoleAsync(RoleRequestDto RoleDto)
        {
            var existRole = await roleRepository.GetRoleByNameAsync(RoleDto.Name);
            if (existRole is not null)
            {
                return RoleErrors.RoleAlreadyExists;
            }
            var Role = mapper.Map<Role>(RoleDto);
            var result = await roleRepository.CreateRoleAsync(Role);
            if (result is null)
            {
                return RoleErrors.RoleCreationFailed;
            }
            var response = mapper.Map<RoleResponseDto>(result);
            return response;
        }
        public async Task<ErrorOr<RoleResponseDto>> UpdateRoleAsync(long roleId, RoleRequestDto roleDto)
        {
            var Role = await roleRepository.GetRoleByIdAsync(roleId);
            if (Role is null)
            {
                return RoleErrors.RoleNotFound;
            }
            var updatedRole = mapper.Map<Role>(roleDto);
            var result = await roleRepository.UpdateRoleAsync(updatedRole, roleId);
            var response = mapper.Map<RoleResponseDto>(result);
            if (response is not null)
            {
                return response;
            }
            return RoleErrors.RoleUpdateFailed;
        }
        public async Task<IEnumerable<RoleResponseDto>> GetRolesAsync()
        {
            var Roles = await roleRepository.GetRolesAsync();
            var response = mapper.Map<IEnumerable<RoleResponseDto>>(Roles);
            return response;
        }
        public async Task<ErrorOr<RoleResponseDto>> GetRoleByIdAsync(long roleId)
        {
            var role = await roleRepository.GetRoleByIdAsync(roleId);
            if (role is null)
            {
                return RoleErrors.RoleNotFound;
            }

            var response = mapper.Map<RoleResponseDto>(role);
            return response;
        }
        public async Task<ErrorOr<SuccessResponse>> DeleteRoleAsync(long roleId)
        {
            var role = await roleRepository.GetRoleByIdAsync(roleId);
            if (role is null)
            {
                return RoleErrors.RoleNotFound;
            }
            var result = await roleRepository.DeleteRoleAsync(roleId);
            if (!result)
            {
                return RoleErrors.RoleDeletionFailed;
            }
            return new SuccessResponse("Role deleted successfully");
        }
    }
}
