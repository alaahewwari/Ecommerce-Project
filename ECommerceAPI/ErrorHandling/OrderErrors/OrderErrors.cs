using ErrorOr;
namespace ECommerceAPI.ErrorHandling.OrderErrors
{
    public class OrderErrors
    {
        public static readonly Error OrderNotFound = Error.NotFound(
            code: "OrderNotFound",
            description: "The specified order could not be found.");
        public static readonly Error OrderCreationFailed = Error.Failure(
            code: "OrderCreationFailed",
            description: "Failed to create the order.");
        public static readonly Error OrderUpdateFailed = Error.Failure(
            code: "OrderUpdateFailed",
            description: "Failed to update the order.");
        public static readonly Error OrderDeletionFailed = Error.Failure(
            code: "OrderDeletionFailed",
            description: "Failed to delete the order.");
    }
}