using ECommerceAPI.Common;
using ECommerceAPI.Dtos.Role.Requests;
using ECommerceAPI.Dtos.Role.Responses;
using ErrorOr;
namespace ECommerceAPI.Services.RoleServices.Interfaces
{
    public interface IRoleService
    {
        Task<ErrorOr<RoleResponseDto>> CreateRoleAsync(RoleRequestDto roleDto);
        Task<ErrorOr<RoleResponseDto>> UpdateRoleAsync(long roleId, RoleRequestDto roleDto);
        Task<IEnumerable<RoleResponseDto>> GetRolesAsync();
        Task<ErrorOr<RoleResponseDto>> GetRoleByIdAsync(long roleId);
        Task<ErrorOr<SuccessResponse>> DeleteRoleAsync(long roleId);
    }
}
