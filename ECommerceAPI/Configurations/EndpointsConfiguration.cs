﻿using ECommerceAPI.Endpoints;
namespace ECommerceAPI.Configurations
{
    public static class EndpointsConfiguration 
    {
        public static void MapAuthenticationEndpoints(this WebApplication app)
        {
            app.MapPost("/api/auth/registration", AuthenticationEndpoints.Register);
            app.MapGet("/api/auth/email-confirmation", AuthenticationEndpoints.ConfirmEmail);
            app.MapPost("/api/auth/login", AuthenticationEndpoints.Login);
            app.MapPost("/api/auth/refresh-token", AuthenticationEndpoints.RefreshToken);
            app.MapPost("/api/auth/forgot-password", AuthenticationEndpoints.ForgotPassword);
            app.MapPost("/api/auth/password-reset", AuthenticationEndpoints.ResetPassword);
            app.MapPost("/api/auth/password-change", AuthenticationEndpoints.ChangePassword);
        }
        public static void MapProductEndpoints(this WebApplication app)
        {
            app.MapPost("/api/products", ProductEndpoints.CreateProduct);
            app.MapGet("/api/products", ProductEndpoints.GetProducts);
                app.MapGet("/api/products/{id}", ProductEndpoints.GetProductById);
            app.MapPut("/api/products/{id}", ProductEndpoints.UpdateProduct);
        app.MapDelete("/api/products/{id}", ProductEndpoints.DeleteProduct);
            app.MapPost("/api/products/{id}/attributes/{attributeValueId}", ProductEndpoints.AddAttributeToProduct);
            app.MapGet("/api/products/{id}/attributes", ProductEndpoints.GetProductAttributes);
            app.MapPut("/api/products/{id}/attributes/{attributeValueId}", ProductEndpoints.UpdateProductAttribute);
            app.MapDelete("/api/products/{id}/attributes/{attributeValueId}", ProductEndpoints.DeleteProductAttribute);
        }
        public static void MapCategoryEndpoints(this WebApplication app)
        {
            app.MapPost("/api/categories", CategoryEndpoints.CreateCategory);
            app.MapPut("/api/categories/{id}", CategoryEndpoints.UpdateCategory);
            app.MapGet("/api/categories", CategoryEndpoints.GetCategories);
            app.MapGet("/api/categories/{id}", CategoryEndpoints.GetCategoryById);
            app.MapDelete("/api/categories/{id}", CategoryEndpoints.DeleteCategory);
        }
        public static void MapBrandEndpoints(this WebApplication app)
        {
            app.MapPost("/api/brands", BrandEndpoints.CreateBrand);
            app.MapPut("/api/brands/{id}", BrandEndpoints.UpdateBrand);
            app.MapGet("/api/brands", BrandEndpoints.GetBrands);
            app.MapGet("/api/brands/{id}", BrandEndpoints.GetBrandById);
            app.MapDelete("/api/brands/{id}", BrandEndpoints.DeleteBrand);
        }
        public static void MapOrderEndpoints(this WebApplication app)
        {
        }
        public static void MapReviewEndpoints(this WebApplication app)
        {

        }
        public static void MapUserEndpoints(this WebApplication app)
        {
            app.MapPost("/api/users/{id}/roles/{roleId}", UserEndpoints.AssignRoleToUser);
            app.MapPost("/api/users", UserEndpoints.CreateUser);
            app.MapPut("/api/users/{id}", UserEndpoints.UpdateUser);
            app.MapGet("/api/users", UserEndpoints.GetUsers);
            app.MapGet("/api/users/{id}", UserEndpoints.GetUserById);
            app.MapDelete("/api/users/{id}", UserEndpoints.DeleteUser);
        }
        public static void MapCartEndpoints(this WebApplication app)
        {
        }
        public static void MapCustomerEndpoints(this WebApplication app)
        {
        }
        public static void MapRoleEndpoints(this WebApplication app)
        {
            app.MapPost("/api/roles", RoleEndpoints.CreateRole);
            app.MapPut("/api/roles/{id}", RoleEndpoints.UpdateRole);
            app.MapGet("/api/roles", RoleEndpoints.GetRoles);
            app.MapGet("/api/roles/{id}", RoleEndpoints.GetRoleById);
            app.MapDelete("/api/roles/{id}", RoleEndpoints.DeleteRole);
        }
        public static void MapPaymentEndpoints(this WebApplication app)
        {
        }
    }
}
