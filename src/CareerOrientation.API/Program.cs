using CareerOrientation.API.StartupConfig;
using CareerOrientation.Services.Mediator;
using CareerOrientation.Services.Validation;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(MediatorEntryPoint).Assembly);
});
builder.Services.AddValidatorsFromAssembly(typeof(FluentValidationEntryPoint).Assembly);

builder.AddSwaggerServices();
builder.AddEfCoreDbProvider();
builder.AddIdentityServices();
builder.AddAuthServices();
builder.AddRepositories();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.CreateIdentityRoles();

app.UseCustomCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
