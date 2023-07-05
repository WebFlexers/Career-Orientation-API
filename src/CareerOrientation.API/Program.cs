using AspNetCoreRateLimit;

using CareerOrientation.API.StartupConfig;
using CareerOrientation.Application;
using CareerOrientation.Infrastructure;

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
    
    builder.Logging.AddWatchDogLogger();
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
    
    Console.WriteLine("test");
    
    app.UseCustomCors();

    app.UseHttpsRedirection();

    app.UseIpRateLimiting();
    
    app.UseAuthentication();
    app.UseAuthorization();
    
    app.UseResponseCaching();
    
    app.UseWatchDogExceptionLogger();
    app.UseWatchDog(opts =>
    {
        opts.WatchPageUsername = app.Configuration["WatchDog:Username"];
        opts.WatchPagePassword = app.Configuration["WatchDog:Password"];
        opts.Serializer = WatchDogSerializerEnum.Newtonsoft;
    });

    app.UseExceptionHandler("/error");

    app.MapControllers();

    app.Run();
}