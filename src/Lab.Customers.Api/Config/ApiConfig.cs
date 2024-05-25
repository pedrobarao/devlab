namespace Lab.Customers.Api.Config;

public static class ApiConfig
{
    public static IServiceCollection AddApiConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerConfig();
        services.RegisterServices(configuration);

        return services;
    }

    public static WebApplication UseApiConfig(this WebApplication app)
    {
        app.UseSwaggerConfig();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }
}