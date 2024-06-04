namespace ECommerceAPI.Utilities.Email
{
    public static class ConfirmationUrlBuilder
    {
public static string BuildConfirmationUrl(string baseUrl, string email, string token)
        {
            var encodedEmail = Uri.EscapeDataString(email);
            var encodedToken = Uri.EscapeDataString(token);
            return $"{baseUrl}?email={encodedEmail}&token={encodedToken}";
        }
    }
}
