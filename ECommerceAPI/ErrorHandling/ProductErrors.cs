using ErrorOr;
namespace ECommerceAPI.ErrorHandling
{
    public class ProductErrors
    {
        public static readonly Error ProductNotFound = Error.NotFound(
           code: "ProductNotFound",
           description: "The specified product could not be found.");
        public static readonly Error ProductAlreadyExists = Error.Conflict(
            code: "ProductAlreadyExists",
            description: "A product with the same name already exists.");
        public static readonly Error ProductInvalid = Error.Validation(
            code: "ProductInvalid",
            description: "The provided product data is invalid.");
        public static readonly Error ProductUpdateFailed = Error.Failure(
            code: "ProductUpdateFailed",
            description: "Failed to update the product.");
        public static readonly Error ProductDeletionFailed = Error.Failure(
            code: "ProductDeletionFailed",
            description: "Failed to delete the product.");
        public static readonly Error ProductCreationFailed = Error.Failure(
                       code: "ProductCreationFailed",
                       description: "Failed to create the product.");
    }
}