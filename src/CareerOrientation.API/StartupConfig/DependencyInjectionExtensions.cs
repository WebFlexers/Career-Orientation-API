using System.Reflection;
using System.Text;
using CareerOrientation.Data;
using CareerOrientation.Data.Entities.Users;
using CareerOrientation.Services.Auth;
using CareerOrientation.Services.Auth.Abstractions;
using CareerOrientation.Services.Validation.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace CareerOrientation.API.StartupConfig;

public static class DependencyInjectionExtensions
{
    public static void AddSwaggerServices(this WebApplicationBuilder builder)
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
            
        builder.Services.AddSwaggerGen(opts =>
        {
            opts.AddSecurityDefinition("bearerAuth", securityScheme);
            opts.AddSecurityRequirement(securityRequirements);
            opts.SwaggerDoc("v1", new OpenApiInfo 
            { 
                Version = "v1",
                Title = "Career Orientation API",
                Description = "This API powers the Career Orientation App based on University of Peireus",
            });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            opts.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
        });
    }

    public static void AddEfCoreDbProvider(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationDbContext> (options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
        });
    }

    public static void AddIdentityServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity<User, IdentityRole>(options => {
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

        builder.Services.AddScoped<IRoleManagerService, RoleManagerService>();
    }

    public static async Task CreateIdentityRoles(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        var roles = AppRoles.GetAllRoles();
        foreach (var role in roles)
        {
            if (await roleManager.RoleExistsAsync(role) == false)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }

    public static void AddAuthServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorization(opts =>
        {
            opts.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
        });

        builder.Services.AddAuthentication(options =>
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
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]!)
                ),
                ClockSkew = TimeSpan.FromSeconds(10)
            };
        });

         builder.Services.AddScoped<ITokenCreationService, JwtService>();
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
