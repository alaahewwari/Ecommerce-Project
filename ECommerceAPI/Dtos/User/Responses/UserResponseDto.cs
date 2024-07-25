using ECommerceAPI.Dtos.Role.Responses;

namespace ECommerceAPI.Dtos.User.Responses
{
    public class UserResponseDto
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public RoleResponseDto Role { get; set; }
    }
}
