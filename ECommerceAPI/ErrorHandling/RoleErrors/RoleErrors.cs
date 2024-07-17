using ErrorOr;
namespace ECommerceAPI.ErrorHandling.RoleErrors
{
    public class RoleErrors
    {
        public static readonly Error RoleNotFound = Error.NotFound(
           code: "RoleNotFound",
           description: "The specified role could not be found.");
        public static readonly Error RoleAlreadyExists = Error.Conflict(
            code: "RoleAlreadyExists",
            description: "A role with the same name already exists.");
        public static readonly Error RoleInvalid = Error.Validation(
            code: "RoleInvalid",
            description: "The provided role data is invalid.");
        public static readonly Error RoleCreationFailed = Error.Failure(
            code: "RoleCreationFailed",
            description: "Failed to create the role.");
        public static readonly Error RoleUpdateFailed = Error.Failure(
            code: "RoleUpdateFailed",
            description: "Failed to update the role.");
        public static readonly Error RoleDeletionFailed = Error.Failure(
            code: "RoleDeletionFailed",
            description: "Failed to delete the role.");
    }
}