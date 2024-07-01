using System.Net;
namespace ECommerceAPI.Utilities.Email
{
    public static class ConfirmationUrlBuilder
    {
        public static string BuildConfirmationUrl(string baseUrl, string email, string token)
        {
            var encodedEmail = WebUtility.UrlEncode(email);
            var encodedToken = WebUtility.UrlEncode(token);
            return $"{baseUrl}?email={encodedEmail}&token={encodedToken}";
        }
    }
}
