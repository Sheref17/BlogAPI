using ApplicationLayer.Interfaces;
using CoreLayer.IRepos;
using InfrastructureLayer.Data.Contexts;
using InfrastructureLayer.Identity;
using InfrastructureLayer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PersistenceLayer.Repos;
using PersistenceLayer.Services;
using System.Text;

namespace InfrastructureLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
         
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"));
            });

  
            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

      
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                    JwtBearerDefaults.AuthenticationScheme;

                options.DefaultChallengeScheme =
                    JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],

                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(
                                    configuration["Jwt:Key"]!))
                    };
            });

            services.AddHttpContextAccessor();

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IJWTService, JWTService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IPostQueryService, PostQueryService>();
            services.AddScoped<ICategoryService, CategoryService>();

         
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICategroyRepository, CategroyRepository>();

            return services;
        }
    }
}