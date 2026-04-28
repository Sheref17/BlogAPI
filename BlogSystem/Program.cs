
using ApplicationLayer;
using BlogSystem.Extensions;
using BlogSystem.Middlewares;
using InfrastructureLayer;
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
