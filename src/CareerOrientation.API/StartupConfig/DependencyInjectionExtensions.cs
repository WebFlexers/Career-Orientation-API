using System.Reflection;
using CareerOrientation.API.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;

namespace CareerOrientation.API.StartupConfig;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerServices();
        services.AddSingleton<ProblemDetailsFactory, CareerOrientationProblemDetailsFactory>();
        return services;
    }
    
    private static void AddSwaggerServices(this IServiceCollection services)
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
