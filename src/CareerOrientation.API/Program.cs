using CareerOrientation.API.StartupConfig;
using CareerOrientation.Application;
using CareerOrientation.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddCors();

    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    
    app.UseCustomCors();

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();
    
    app.UseExceptionHandler("/error");

    app.MapControllers();

    app.Run();
}