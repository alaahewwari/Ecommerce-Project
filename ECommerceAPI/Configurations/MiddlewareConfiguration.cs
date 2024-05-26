namespace ECommerceAPI.Configurations
{
    public static class MiddlewareConfiguration
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
        }
    }
}
