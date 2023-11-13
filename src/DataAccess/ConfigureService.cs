using ECommerse.Core.Identity;
using ECommerse.DataAccess.CustomValidations;
using ECommerse.DataAccess.Localizations;
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
        services.AddIdentity<AppUser, AppRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.User.AllowedUserNameCharacters = " qüertyuiopöğasdfghjklıəzxcvbnmçş.QÜERTYUIOPÖĞASDFGHJKLIƏZXCVBNMÇŞ_0123456789@";

            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = false;

            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
            options.Lockout.MaxFailedAccessAttempts = 3;
        })
        .AddPasswordValidator<PasswordValidator>()
        .AddUserValidator<UserValidator>()
        .AddErrorDescriber<LocalizationIdentityErrorDescriber>()
        .AddEntityFrameworkStores<ECommerseDbContext>()
        .AddDefaultTokenProviders();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
