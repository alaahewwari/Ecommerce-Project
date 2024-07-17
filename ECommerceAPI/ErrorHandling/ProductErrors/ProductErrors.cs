using ErrorOr;
namespace ECommerceAPI.ErrorHandling.ProductErrors
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
        public static readonly Error AttributeNotFound = Error.NotFound(
                       code: "AttributeNotFound",
                       description: "The specified attribute could not be found.");
        public static readonly Error ProductAttributeCreationFailed = Error.Failure(
                       code: "ProductAttributeCreationFailed",
                       description: "Failed to add the attribute to the product.");
        public static readonly Error ProductAttributeUpdateFailed = Error.Failure(
                       code: "ProductAttributeUpdateFailed",
                       description: "Failed to update the attribute of the product.");
        public static readonly Error ProductAttributeDeletionFailed = Error.Failure(
                       code: "ProductAttributeDeletionFailed",
                       description: "Failed to delete the attribute from the product.");
    }
}