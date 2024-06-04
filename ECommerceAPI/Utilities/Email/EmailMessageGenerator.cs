using ECommerceAPI.Constants.Email;
using MimeKit;
namespace ECommerceAPI.Utilities.Email
{
    public static class EmailMessageGenerator
    {
        public static MimeEntity GenerateConfirmEmailMessageBody(string url)
        {
            var builder = new BodyBuilder();
            // Read the template from the file
            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "HtmlEmailTemplates", "EmailConfirmationTemplate.html");
            string emailTemplate = File.ReadAllText(templatePath);
            // Replace placeholders with actual values
            string messageBody = emailTemplate.Replace("{Url}", url)
                .Replace("{ImageUrl}", EmailUrlConstants.ConfirmationImageUrl);
            builder.HtmlBody = messageBody;
            return builder.ToMessageBody();
        }
    }
}
