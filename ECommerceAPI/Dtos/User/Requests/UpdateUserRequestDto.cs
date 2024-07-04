namespace ECommerceAPI.Dtos.User.Requests
{
    public class UpdateUserRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long RoleId { get; set; }
    }
}