using ECommerse.WebUI.Enums;
using ECommerse.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace ECommerse.WebUI;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUiServices(this IServiceCollection services)
    {
        //builder.Services.AddScoped<IClaimsTransformation, ClaimProvider>();
        services.AddTransient<IAuthorizationHandler, OneMonthTrialHandler>();
        services.AddAuthorization(opts =>
        {
            opts.AddPolicy("GenderPolicy", policy =>
            {
                policy.RequireClaim("gender", Gender.Bay.ToString());
            });

            opts.AddPolicy("AdulthoodPolicy", policy =>
            {
                policy.RequireClaim("adult");
            });
            opts.AddPolicy("TrialPolicy", policy =>
            {
                policy.AddRequirements(new OneMonthTrialRequirement());
            });
        });

        services.ConfigureApplicationCookie(options =>
        {
            CookieBuilder cookieBuilder = new()
            {
                Name = "NonAvmCookie"
            };
            options.LoginPath = new PathString("/Auth/Login");
            options.LogoutPath = new PathString("/Auth/Logout");
            options.Cookie = cookieBuilder;
            options.ExpireTimeSpan = TimeSpan.FromDays(60);
            options.SlidingExpiration = true;

        });

        services.AddScoped<PhotoHandlerService>();

        services.AddLocalization(options => options.ResourcesPath = "Resources");

        var cultureInfos = new[]
        {
            new CultureInfo("az-AZ"),
            new CultureInfo("en-US"),
        };

        services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = cultureInfos;
            options.DefaultRequestCulture = new RequestCulture(supportedCultures[0]);
            options.SupportedUICultures = supportedCultures;
        });

        return services;
    }
}
