using System.Text;

using AspNetCoreRateLimit;

using CareerOrientation.API.StartupConfig;
using CareerOrientation.Application;
using CareerOrientation.Infrastructure;

using Microsoft.AspNetCore.HttpOverrides;

Console.OutputEncoding = Encoding.UTF8;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddCors();
    
    builder.Services
        .AddPresentation(builder.Configuration)
        .AddApplication()
        .AddInfrastructure(builder.Configuration, builder.Environment);
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.DisplayRequestDuration();
        });
    }
    else if (app.Environment.IsProduction())
    {
        // In production we are using a reverse proxy through nginx
        // so we need to setup the forwarded headers correctly
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });
    }

    app.UseCustomCors();

    if (app.Environment.IsDevelopment())
    {
        // In production we are using a reverse proxy through nginx
        // so we do not need https redirection
        app.UseHttpsRedirection();
    }

    app.UseIpRateLimiting();
    
    app.UseAuthentication();
    app.UseAuthorization();
    
    app.UseResponseCaching();
    app.UseExceptionHandler("/error");

    app.MapControllers();

    app.Run();
}