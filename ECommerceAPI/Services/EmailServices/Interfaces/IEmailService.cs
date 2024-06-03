namespace ECommerceAPI.Services.EmailServices.Interfaces;
public interface IEmailService
{
        Task SendEmailAsync(string to, string subject, string body);
    Task SendConfirmationEmailAsync(string to, string url);
}