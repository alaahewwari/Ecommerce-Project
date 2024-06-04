using ECommerceAPI.Services.UrlBuilder.Interfaces;
namespace ECommerceAPI.Services.UrlBuilder.Implementations
{
    public class UrlBuilder
        (IConfiguration configuration)
        : IUrlBuilder
    {
        public string GetRegistrationUrl()
        {
            return $"{configuration["ApiSettings:AuthBaseUrl"]}/register";
        }

        public string GetEmailConfirmationUrl()
        {
            return $"{configuration["ApiSettings:AuthBaseUrl"]}/email-confirmation";
        }
    }
}
