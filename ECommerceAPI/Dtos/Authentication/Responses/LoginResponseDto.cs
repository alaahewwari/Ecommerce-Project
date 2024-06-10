namespace ECommerceAPI.Dtos.Authentication.Responses
{
    public class LoginResponseDto
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiryTime { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
