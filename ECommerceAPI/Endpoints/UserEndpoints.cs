using ECommerceAPI.Dtos.User.Requests;
using ECommerceAPI.Services.UserServices.Interfaces;
namespace ECommerceAPI.Endpoints
{
    public class UserEndpoints
    {
        public static async Task<IResult> AssignRoleToUser(IUserService userService, long userId, long roleId)
        {
            var response = await userService.AssignRoleToUserAsync(userId, roleId);
            if (response.IsError)
            {
                return Results.BadRequest(response.Errors);
            }
            return Results.Ok(response.Value);
        }
        public static async Task<IResult> GetUserById(IUserService userService, long id)
        {
            var response = await userService.GetUserByIdAsync(id);
            if (response.IsError)
            {
                return Results.BadRequest(response.Errors);
            }
            return Results.Ok(response.Value);
        }
        public static async Task<IResult> GetUsers(IUserService userService)
        {
            var response = await userService.GetAllUsersAsync();
            return Results.Ok(response);
        }
        public static async Task<IResult> CreateUser(IUserService userService,UserRequestsDto userDto)
        {
            var response = await userService.CreateUserAsync(userDto);
            if (response.IsError)
            {
                return Results.BadRequest(response.Errors);
            }
            return Results.Ok(response.Value);
        }
        public static async Task<IResult> UpdateUser(IUserService userService,UpdateUserRequestDto  userDto, long id)
        {
            var response = await userService.UpdateUserAsync(id,userDto);
            if (response.IsError)
            {
                return Results.BadRequest(response.Errors);
            }
            return Results.Ok(response.Value);
        }
        public static async Task<IResult> DeleteUser(IUserService userService, long id)
        {
            var response = await userService.DeleteUserAsync(id);
            if (response.IsError)
            {
                return Results.BadRequest(response.Errors);
            }
            return Results.Ok(response.Value);
        }
    }
}
