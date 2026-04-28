
using ApplicationLayer;
using ApplicationLayer.Behaviors;
using ApplicationLayer.CQRS.Blog.Commands.Create;
using ApplicationLayer.Interfaces;
using BlogSystem.Extensions;
using BlogSystem.Middlewares;
using CoreLayer.IRepos;
using FluentValidation;
using InfrastructureLayer;
using InfrastructureLayer.Data.Contexts;
using InfrastructureLayer.Identity;
using InfrastructureLayer.Services;
using MediatR;
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

    

            builder.Services.AddControllers();
        
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);


            var app = builder.Build();

            await app.Services.SeedIdentityDataAsync();




            app.UseSwagger();
             app.UseSwaggerUI();
      

            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

                app.Run();
        }
    }
}
