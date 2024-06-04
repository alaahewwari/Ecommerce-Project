namespace ECommerceAPI.Configurations
{
    public static class MiddlewaresConfiguration
    {
        public static void UseMiddleware(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerceAPI v1"));
            }
            app.UseHttpsRedirection();
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
