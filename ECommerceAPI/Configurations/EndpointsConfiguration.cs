using ECommerceAPI.Endpoints;

namespace ECommerceAPI.Configurations
{
    public static class EndpointsConfiguration 
    {
        public static void MapProductEndpoints(this WebApplication app)
        {
            app.MapPost("/api/products", ProductEndpoints.CreateProduct);
        }
        public static void MapCategoryEndpoints(this WebApplication app)
        {
            app.MapGet("/api/categories", CategoryEndpoints.GetCategories);
        }
        public static void MapBrandEndpoints(this WebApplication app)
        {
            app.MapGet("/api/brands", BrandEndpoints.GetBrands);
        }
    }
}
