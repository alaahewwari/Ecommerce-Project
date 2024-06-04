using ErrorOr;

namespace ECommerceAPI.ErrorHandling
{
    public static class CategoryErrors
    {
        public static readonly Error CategoryNotFound = Error.NotFound(
                       code: "CategoryNotFound",
                       description: "The specified category could not be found.");

        public static readonly Error CategoryAlreadyExists = Error.Conflict(
                       code: "CategoryAlreadyExists",
                       description: "A category with the same name already exists.");

        public static readonly Error CategoryInvalid = Error.Validation(
                       code: "CategoryInvalid",
                       description: "The provided category data is invalid.");
        public static readonly Error CategoryCreationFailed = Error.Failure(
                                  code: "CategoryCreationFailed",
                                  description: "Failed to create the category.");
        public static readonly Error CategoryUpdateFailed = Error.Failure(
                       code: "CategoryUpdateFailed",
                       description: "Failed to update the category.");

        public static readonly Error CategoryDeletionFailed = Error.Failure(
                       code: "CategoryDeletionFailed",
                       description: "Failed to delete the category.");
    }
}
