using ECommerceAPI.Services.AuthenticationServices.Interfaces;
using System.Security.Claims;
namespace ECommerceAPI.Services.AuthenticationServices.Implementations
{
    public class AuthenticatedUserService(
        IHttpContextAccessor httpContextAccessor
        ) : IAuthenticatedUserService
    {
        public long GetAuthenticatedUserIdAsync()
        {
            long userId = 0;
            if (httpContextAccessor.HttpContext != null)
            {
                var NameIdentifier = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (NameIdentifier != null)
                {
                    userId = long.Parse(NameIdentifier);
                    return userId;
                }
            }
            return userId;
        }
    }
}
