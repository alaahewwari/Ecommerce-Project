using ErrorOr;
namespace ECommerceAPI.ErrorHandling
{
    public static class IdentityErrors
    {
        public static readonly Error InvalidToken = Error.Validation(
            code: "InvalidToken",
            description: "The provided token is invalid.");
        public static readonly Error UserNotFound = Error.NotFound(
            code: "UserNotFound",
            description: "User does not exist.");
        public static readonly Error UserAlreadyExists = Error.Conflict(
            code: "UserAlreadyExists",
            description: "User already exists.");
        public static readonly Error UserCreationFailed = Error.Failure(
            code: "UserCreationFailed",
            description: "Failed to create the user.");
    }
}
