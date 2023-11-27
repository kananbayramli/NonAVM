using ECommerse.WebUI.Services;

namespace ECommerse.WebUI;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUiServices(this IServiceCollection services)
    {
        services.AddScoped<PhotoHandlerService>();

        return services;
    }
}
