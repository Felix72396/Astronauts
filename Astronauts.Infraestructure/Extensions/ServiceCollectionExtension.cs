using Astronauts.Core.CustomEntities;
using Astronauts.Core.Entities;
using Astronauts.Core.Interfaces;
using Astronauts.Core.Services;
using Astronauts.Infraestructure.Interfaces;
using Astronauts.Infraestructure.Options;
using Astronauts.Infraestructure.Repositories;
using Astronauts.Infraestructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


namespace Astronauts.Infraestructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AstronautMediaContext>(options => options.UseSqlServer(configuration.GetConnectionString("AstronautDB")));
    }

    public static void AddOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PaginationOptions>(configuration.GetSection("Pagination"));
        services.Configure<PasswordOptions>(configuration.GetSection("PasswordOptions"));
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IAstronautService, AstronautService>();
        services.AddTransient<IMissionService, MissionService>();
        services.AddTransient<ISocialMediaService, SocialMediaService>();
        services.AddTransient<IAstronautMissionService, AstronautMissionService>();
        services.AddTransient<ISecurityService, SecurityService>();
        services.AddTransient<IMissionRepository, MissionRepository>();
        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        services.AddSingleton<IPasswordService, PasswordService>();

        services.AddSingleton<IUriService>(provider =>
        {
            var accesor = provider.GetRequiredService<IHttpContextAccessor>();
            var request = accesor?.HttpContext?.Request;
            var absoluteUri = string.Concat(request?.Scheme, "://", request?.Host.ToUriComponent());
            return new UriService(absoluteUri);
        });
    }

    public static IServiceCollection AddJwtAuthentications(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Authentication:Issuer"],
                ValidAudience = configuration["Authentication:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]))
            };
        });

        return services;
    }

    public static void AddSwagger(this IServiceCollection services, string xmlFileName)
    {
        services.AddSwaggerGen(doc =>
        {
            doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Astronaut API", Version = "v1" });

            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
            doc.IncludeXmlComments(xmlPath);
        });
    }


 
}
