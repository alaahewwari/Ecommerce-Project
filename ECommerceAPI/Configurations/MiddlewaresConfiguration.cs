namespace ECommerceAPI.Configurations
{
    public static class MiddlewaresConfiguration
    {
        public static void MapEndpoints(this WebApplication app)
        {
            app.MapAuthenticationEndpoints();
            app.MapCategoryEndpoints();
            app.MapBrandEndpoints();
            app.MapProductEndpoints();
            app.MapOrderEndpoints();
            app.MapPaymentEndpoints();
            app.MapUserEndpoints();
            app.MapRoleEndpoints();
            app.MapCustomerEndpoints();
            app.MapCartEndpoints();
            app.MapReviewEndpoints();
        }
    }
}
