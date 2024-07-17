using ErrorOr;
namespace ECommerceAPI.ErrorHandling.UserErrors
{
    public class UserErrors
    {
        public static readonly Error RoleAssignmentFailed = Error.Failure(
            code: "RoleAssignmentFailed",
            description: "Failed to assign the role to the user.");
        public static readonly Error UserCreationFailed = Error.Failure(
            code: "UserCreationFailed",
            description: "Failed to create the user.");
        public static readonly Error UserUpdateFailed = Error.Failure(
            code: "UserUpdateFailed",
            description: "Failed to update the user.");
        public static readonly Error UserDeletionFailed = Error.Failure(
            code: "UserDeletionFailed",
            description: "Failed to delete the user.");

    }
}
