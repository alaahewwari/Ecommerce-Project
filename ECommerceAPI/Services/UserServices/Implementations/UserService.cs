using AutoMapper;
using ECommerceAPI.Common;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Dtos.User.Requests;
using ECommerceAPI.Dtos.User.Responses;
using ECommerceAPI.ErrorHandling;
using ECommerceAPI.Repositories.Interfaces;
using ECommerceAPI.Services.IdentityServices.Interfaces;
using ECommerceAPI.Services.UserServices.Interfaces;
using ErrorOr;
namespace ECommerceAPI.Services.UserServices.Implementations
{
    public class UserService(
        IUserRepository userRepository,
        IIdentityService identityService,
        IMapper mapper,
        IRoleRepository roleRepository) : IUserService
    {
        public async Task<ErrorOr<UserResponseDto>> AssignRoleToUserAsync(long userId, long roleId)
        {
            var user = await identityService.FindByIdAsync(userId);
            if (user == null)
            {
                return IdentityErrors.UserNotFound;
            }
            var role = await roleRepository.GetRoleByIdAsync(roleId);
            if (role == null)
            {
                return RoleErrors.RoleNotFound;
            }
            var result = await userRepository.AssignRoleToUserAsync(user, role);
            if (result == null)
            {
                return UserErrors.RoleAssignmentFailed;
            }
            var response = mapper.Map<UserResponseDto>(result);
            return response;
        }
        public async Task<ErrorOr<UserResponseDto>> GetUserByIdAsync(long id)
        {
            var user = await userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return IdentityErrors.UserNotFound;
            }
            var response = mapper.Map<UserResponseDto>(user);
            return response;
        }
        public async Task<IList<UserResponseDto>> GetAllUsersAsync()
        {
            var users = await userRepository.GetAllUsersAsync();
            var response = mapper.Map<IList<UserResponseDto>>(users);
            return response;
        }
        public async Task<ErrorOr<UserResponseDto>> CreateUserAsync(UserRequestsDto userDto)
        {
            var user = mapper.Map<User>(userDto);
            var result = await userRepository.CreateUserAsync(user);
            if (result is null)
            {
                return UserErrors.UserCreationFailed;
            }
            var response = mapper.Map<UserResponseDto>(result);
            return response;
        }
        public async Task<ErrorOr<UserResponseDto>> UpdateUserAsync(long id, UpdateUserRequestDto userDto)
        {
            var user = await userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return IdentityErrors.UserNotFound;
            }
            var updatedUser = mapper.Map<User>(userDto);
            updatedUser.Id = id;
            var result = await userRepository.UpdateUserAsync(updatedUser);
            if (result == null)
            {
                return UserErrors.UserUpdateFailed;
            }
            var response = mapper.Map<UserResponseDto>(result);
            return response;
        }
        public async Task<ErrorOr<SuccessResponse>> DeleteUserAsync(long id)
        {
            var user = await userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return IdentityErrors.UserNotFound;
            }
            var result = await userRepository.DeleteUserAsync(id);
            if (!result)
            {
                return UserErrors.UserDeletionFailed;
            }
            return new SuccessResponse("User deleted successfully");
        }
    }
}