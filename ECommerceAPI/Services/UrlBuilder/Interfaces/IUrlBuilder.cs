namespace ECommerceAPI.Services.UrlBuilder.Interfaces
{
    public interface IUrlBuilder
    {
        string GetRegistrationUrl();
        string GetEmailConfirmationUrl();
    }
}
