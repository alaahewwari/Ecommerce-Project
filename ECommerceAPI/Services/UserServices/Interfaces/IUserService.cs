using ECommerceAPI.Common;
using ECommerceAPI.Dtos.User.Requests;
using ECommerceAPI.Dtos.User.Responses;
using ErrorOr;
namespace ECommerceAPI.Services.UserServices.Interfaces
{
    public interface IUserService
    {
        Task<ErrorOr<UserResponseDto>> AssignRoleToUserAsync(long userId, long roleId);
        Task<ErrorOr<UserResponseDto>> GetUserByIdAsync(long id);
        Task<IList<UserResponseDto>> GetAllUsersAsync();
        Task<ErrorOr<UserResponseDto>> CreateUserAsync(UserRequestsDto userDto);
        Task<ErrorOr<UserResponseDto>> UpdateUserAsync(long id, UpdateUserRequestDto userDto);
        Task<ErrorOr<SuccessResponse>> DeleteUserAsync(long id);
    }
}