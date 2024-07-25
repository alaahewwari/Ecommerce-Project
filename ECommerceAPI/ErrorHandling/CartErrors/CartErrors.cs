using ErrorOr;

namespace ECommerceAPI.ErrorHandling.CartErrors
{
    public static class CartErrors
    {
        public static readonly Error CartNotFound = Error.Failure(
             code: "CartNotFound",
             description: "Cart not found.");
        public static readonly Error AddToCartFailed = Error.Failure(
             code: "AddToCartFailed",
             description: "Failed to add the product to the cart.");
        public static readonly Error CartItemNotFound = Error.Failure(
             code: "CartItemNotFound",
             description: "Cart item not found.");
        public static readonly Error CartIsEmpty = Error.Failure(
             code: "CartIsEmpty",
             description: "Cart is empty.");
    }
}
