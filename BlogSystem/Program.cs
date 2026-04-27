
using ApplicationLayer;
using ApplicationLayer.Interfaces;
using BlogSystem.Middlewares;
using CoreLayer.IRepos;
using InfrastructureLayer.Data.Contexts;
using InfrastructureLayer.Identity;
using InfrastructureLayer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PersistenceLayer.Identity;
using PersistenceLayer.Repos;
using PersistenceLayer.Services;
using System.Text;

namespace BlogSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMediatR(C => C.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));
            builder.Services.AddScoped<IIdentityService, IdentityService>();
            builder.Services.AddScoped<IJWTService, JWTService>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
            builder.Services.AddScoped<IPostQueryService, PostQueryService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICategroyRepository, CategroyRepository>();
          





            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(options =>
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

                                     ValidIssuer = builder.Configuration["Jwt:Issuer"],
                                     ValidAudience = builder.Configuration["Jwt:Audience"],
                                     IssuerSigningKey = new SymmetricSecurityKey(
                                         Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
                                     )
                                 };
                             });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

                await IdentitySeeder.SeedRolesAsync(roleManager);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
