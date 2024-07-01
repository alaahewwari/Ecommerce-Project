namespace ECommerceAPI.Dtos.Authentication.Requests
{
    public class ResetPasswordRequestDto
    {
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
