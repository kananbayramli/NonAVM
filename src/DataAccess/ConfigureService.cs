using ECommerse.Core.Identity;
using ECommerse.DataAccess.Persistance;
using ECommerse.DataAccess.Repositories.Abstract;
using ECommerse.DataAccess.Repositories.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerse.DataAccess;

public static class ConfigureService
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ECommerseDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("mssql")));
        services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<ECommerseDbContext>()
                .AddDefaultTokenProviders();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
