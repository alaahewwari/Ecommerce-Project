using ErrorOr;

namespace ECommerceAPI.Services.AuthenticationServices.Interfaces
{
    public interface IAuthenticatedUserService
    {
        long GetAuthenticatedUserIdAsync();
    }
}
