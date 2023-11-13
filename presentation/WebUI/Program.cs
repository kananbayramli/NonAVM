using ECommerse.Business;
using ECommerse.Core.Enums;
using ECommerse.DataAccess;
using ECommerse.WebUI;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDataProtection();

builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddBusiness();

//builder.Services.AddScoped<IClaimsTransformation, ClaimProvider>();
builder.Services.AddTransient<IAuthorizationHandler, OneMonthTrialHandler>();
builder.Services.AddAuthorization(opts =>
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


builder.Services.ConfigureApplicationCookie(options =>
{
    CookieBuilder cookieBuilder = new CookieBuilder();

    cookieBuilder.Name = "NonAvmCookie";
    options.LoginPath = new PathString("/Auth/Login");
    options.LogoutPath = new PathString("/Auth/Logout");
    options.Cookie = cookieBuilder;
    options.ExpireTimeSpan = TimeSpan.FromDays(60);
    options.SlidingExpiration = true;

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
