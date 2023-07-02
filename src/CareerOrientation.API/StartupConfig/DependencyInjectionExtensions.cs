using System.Reflection;
using CareerOrientation.API.Common.Errors;

using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;

using Newtonsoft.Json;

using WatchDog;
using WatchDog.src.Enums;

namespace CareerOrientation.API.StartupConfig;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration config)
    {
        services.AddControllers().AddNewtonsoftJson();
        
        services.AddEndpointsApiExplorer()
            .AddSwaggerServices()
            .AddLoggingServices(config)
            .AddSingleton<ProblemDetailsFactory, CareerOrientationProblemDetailsFactory>();
        
        return services;
    }
    
    private static IServiceCollection AddSwaggerServices(this IServiceCollection services)
    {
        var securityScheme = new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Description = "JWT Authorization header info using bearer tokens",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT"
        };

        var securityRequirements = new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "bearerAuth"
                    }
                },
                Array.Empty<string>()
            }
        };
            
        services.AddSwaggerGen(opts =>
        {
            opts.AddSecurityDefinition("bearerAuth", securityScheme);
            opts.AddSecurityRequirement(securityRequirements);
            opts.SwaggerDoc("v1", new OpenApiInfo 
            { 
                Version = "v1",
                Title = "Career Orientation API",
                Description = "This API powers the Career Orientation App based on University of Piraeus",
            });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            opts.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
        });

        return services;
    }

    private static IServiceCollection AddLoggingServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddWatchDogServices(opt => 
        {
            opt.IsAutoClear = true;
            opt.ClearTimeSchedule = WatchDogAutoClearScheduleEnum.Weekly;
            opt.SetExternalDbConnString = config.GetConnectionString("LoggingDb");
            opt.DbDriverOption = WatchDogDbDriverEnum.PostgreSql;
        });

        return services;
    }
    
    public static void UseCustomCors(this WebApplication app)
    {
        var corsConfiguration = app.Configuration.GetSection("Cors");
        var corsSettings = corsConfiguration.GetChildren();

        string[] allowedOrigins = corsSettings.Select(cs => cs.Value!)
            .ToArray();

        app.UseCors(corsBuilder =>
        {
            corsBuilder
                .WithOrigins(allowedOrigins)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        });
    }
}
