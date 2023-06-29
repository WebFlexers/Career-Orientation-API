using System.Diagnostics;
using System.Text;
using System.Text.Json;

using CareerOrientation.Application.Common.Abstractions.Auth;
using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Common.Abstractions.Services;
using CareerOrientation.Domain.Common.DomainErrors;
using CareerOrientation.Domain.Entities;
using CareerOrientation.Infrastructure.Auth;
using CareerOrientation.Infrastructure.Persistence;
using CareerOrientation.Infrastructure.Persistence.Repositories;
using CareerOrientation.Infrastructure.Services;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CareerOrientation.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddIdentity()
            .AddAuth(configuration)
            .AddPersistence(configuration);

        services.AddSingleton<IClock, Clock>();
        
        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthorization(opts =>
        {
            opts.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
        });

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(configuration["Jwt:Key"]!)
                    ),
                    ClockSkew = TimeSpan.FromSeconds(10)
                };
                
                options.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/problem+json";

                        var problemDetails = new ProblemDetails
                        {
                            Type = "https://tools.ietf.org/html/rfc7235#section-3.1",
                            Title = "Unauthorized",
                            Status = StatusCodes.Status401Unauthorized,
                        };
                        
                        var traceId = Activity.Current?.Id ?? context.HttpContext?.TraceIdentifier;
                        if (traceId != null)
                        {
                            problemDetails.Extensions["traceId"] = traceId;
                        }

                        var result = JsonSerializer.Serialize(problemDetails);
                        return context.Response.WriteAsync(result);
                    }
                };
            });
        
        services.AddScoped<ITokenCreationService, JwtService>();
        
        return services;
    }
    
    private static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole>(options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddErrorDescriber<GreekIdentityErrorDescriber>();

        services.AddScoped<IRoleManagerService, RoleManagerService>();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext> (options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Default"));
        });
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITrackRepository, TrackRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ITestsRepository, TestsRepository>();
        
        return services;
    }
    
}