
using ErrorOr;

namespace ECommerceAPI.ErrorHandling
{
    public static class BrandErrors
    {
        public static readonly Error BrandNotFound = Error.NotFound(
           code: "BrandNotFound",
           description: "The specified brand could not be found.");

        public static readonly Error BrandAlreadyExists = Error.Conflict(
            code: "BrandAlreadyExists",
            description: "A brand with the same name already exists.");

        public static readonly Error BrandInvalid = Error.Validation(
            code: "BrandInvalid",
            description: "The provided brand data is invalid.");

        public static readonly Error BrandUpdateFailed = Error.Failure(
            code: "BrandUpdateFailed",
            description: "Failed to update the brand.");

        public static readonly Error BrandDeletionFailed = Error.Failure(
            code: "BrandDeletionFailed",
            description: "Failed to delete the brand.");
    }
}
