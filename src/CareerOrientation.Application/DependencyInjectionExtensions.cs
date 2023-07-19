using CareerOrientation.Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CareerOrientation.Application;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(DependencyInjectionExtensions).Assembly);
        });
        
        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));
        
        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ErrorLoggingBehavior<,>));
        
        services.AddValidatorsFromAssembly(typeof(DependencyInjectionExtensions).Assembly);
        return services;
    }
}