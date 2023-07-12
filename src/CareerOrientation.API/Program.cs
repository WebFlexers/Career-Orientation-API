using AspNetCoreRateLimit;

using CareerOrientation.API.StartupConfig;
using CareerOrientation.Application;
using CareerOrientation.Infrastructure;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using WatchDog;
using WatchDog.src.Enums;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddCors();

    builder.Services
        .AddPresentation(builder.Configuration)
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
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
    
    app.UseCustomCors();

    app.UseHttpsRedirection();

    app.UseIpRateLimiting();
    
    app.UseAuthentication();
    app.UseAuthorization();
    
    app.UseResponseCaching();

    app.UseExceptionHandler("/error");

    app.MapControllers();

    app.Run();
}