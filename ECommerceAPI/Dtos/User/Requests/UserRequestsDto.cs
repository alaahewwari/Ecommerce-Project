namespace ECommerceAPI.Dtos.User.Requests
{
    public class UserRequestsDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public long RoleId { get; set; }
    }
}
