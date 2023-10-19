using ECommerse.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerse.Business;

public static class ConfigureService
{
    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        services.Scan(scan => scan
             .FromAssemblyOf<IOurAssemblyMarker>()
             .AddClasses(classes => classes.AssignableTo<IScoppedLifetime>())
             .AsImplementedInterfaces()
             .WithScopedLifetime()
             .AddClasses());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
