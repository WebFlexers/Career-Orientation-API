using CareerOrientation.Data;
using CareerOrientation.Data.Entities;
using CareerOrientation.Services.Auth;
using CareerOrientation.Services.Auth.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CareerOrientation.API.StartupConfig;

public static class DependencyInjectionExtensions
{
    public static void AddEfCoreDbProvider(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationDbContext> (options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
        });
    }

    public static void AddIdentityServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentityCore<User>(options => {
            options.SignIn.RequireConfirmedAccount = false;
            options.User.RequireUniqueEmail = true;
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>();

        builder.Services.AddTransient<ITokenCreationService, JwtService>();
    }

    public static void AddAuthServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorization(opts =>
        {
            opts.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
        });
    }
}
