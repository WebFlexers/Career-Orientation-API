using System.Diagnostics;
using System.Text;
using System.Text.Json;

using CareerOrientation.Application.Common.Abstractions.Auth;
using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Common.Abstractions.Recommendations;
using CareerOrientation.Application.Common.Abstractions.Services;
using CareerOrientation.Domain.Common.DomainErrors;
using CareerOrientation.Domain.Entities;
using CareerOrientation.Infrastructure.Auth;
using CareerOrientation.Infrastructure.Common.Options;
using CareerOrientation.Infrastructure.Common.Options.Validators;
using CareerOrientation.Infrastructure.Persistence;
using CareerOrientation.Infrastructure.Persistence.Repositories;
using CareerOrientation.Infrastructure.Recommendations;
using CareerOrientation.Infrastructure.Services;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using WatchDog;
using WatchDog.src.Enums;

namespace CareerOrientation.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager config)
    {
        services
            .AddAppSettings(config)
            .AddIdentity()
            .AddAuth(config)
            .AddPersistence(config);

        services.AddSingleton<IClock, Clock>();
        services.AddSingleton<IPointsCalculationService, PointsCalculationService>();
        
        return services;
    }

    private static IServiceCollection AddAppSettings(this IServiceCollection services, ConfigurationManager config)
    {
        services.AddOptions<JwtOptions>()
            .Bind(config.GetRequiredSection(JwtOptions.SectionName))
            .Validate(x => x.ValidateJwtOptions())
            .ValidateOnStart();

        services.AddOptions<ConnectionStringsOptions>()
            .Bind(config.GetSection(ConnectionStringsOptions.SectionName))
            .Validate(x => x.ValidateConnectionStringOptions())
            .ValidateOnStart();

        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager config)
    {
        var jwtOptions = config.GetRequiredSection(JwtOptions.SectionName)
            .Get<JwtOptions>();
        Debug.Assert(jwtOptions is not null);
        
        services.AddAuthorization(opts =>
        {
            /*opts.FallbackPolicy = new AuthorizationPolicyBuilder()
                //.RequireAuthenticatedUser()
                .Build();*/
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
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(jwtOptions.Key)
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

    private static IServiceCollection AddPersistence(this IServiceCollection services, ConfigurationManager config)
    {
        var connectionStrings = config.GetRequiredSection(ConnectionStringsOptions.SectionName)
            .Get<ConnectionStringsOptions>();
        Debug.Assert(connectionStrings is not null);
        
        services.AddDbContext<ApplicationDbContext> (options =>
        {
            options.UseNpgsql(connectionStrings.Default);
        });
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IGradesRepository, GradesRepository>();
        services.AddScoped<ITrackRepository, TrackRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ITestsRepository, TestsRepository>();
        services.AddScoped<IStatisticsRepository, StatisticsRepository>();
        
        return services;
    }
    
}