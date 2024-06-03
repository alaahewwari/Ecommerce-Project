using ECommerceAPI.Endpoints;

namespace ECommerceAPI.Configurations
{
    public static class EndpointsConfiguration 
    {
        public static void MapAuthenticationEndpoints(this WebApplication app)
        {
            app.MapPost("/api/auth/registration", AuthenticationEndpoints.Register);
        app.MapGet("/api/auth/email-confirmation", AuthenticationEndpoints.ConfirmEmail);
        }
        public static void MapProductEndpoints(this WebApplication app)
        {
            app.MapPost("/api/products", ProductEndpoints.CreateProduct);
        }
        public static void MapCategoryEndpoints(this WebApplication app)
        {
            app.MapGet("/api/categories", CategoryEndpoints.GetCategories);
            app.MapGet("/api/categories/{id}", CategoryEndpoints.GetCategoryById);
        }
        public static void MapBrandEndpoints(this WebApplication app)
        {
            app.MapGet("/api/brands", BrandEndpoints.GetBrands);
            app.MapGet("/api/brands/{id}", BrandEndpoints.GetBrandById);
        }
        public static void MapReviewEndpoints(this WebApplication app)
        {
        }
        public static void MapOrderEndpoints(this WebApplication app)
        {
        }
        public static void MapUserEndpoints(this WebApplication app)
        {
        }
        public static void MapCartEndpoints(this WebApplication app)
        {
        }
        public static void MapCustomerEndpoints(this WebApplication app)
        {
        }
        public static void MapRoleEndpoints(this WebApplication app)
        {
        }
        public static void MapPaymentEndpoints(this WebApplication app)
        {
        }
    }
}
