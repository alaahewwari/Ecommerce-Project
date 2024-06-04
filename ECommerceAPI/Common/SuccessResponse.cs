namespace ECommerceAPI.Common
{
    public class SuccessResponse(string successMessage)
    {
        public string SuccessMessage { get; set; } = successMessage;
    }
}
