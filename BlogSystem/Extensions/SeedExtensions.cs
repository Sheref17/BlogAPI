using InfrastructureLayer.Identity;
using Microsoft.AspNetCore.Identity;
using PersistenceLayer.Identity;

namespace BlogSystem.Extensions
{
    public static class SeedExtensions
    {
        public static async Task SeedIdentityDataAsync(this IServiceProvider services)
        {
            using var scope = services.CreateScope();

            var roleManager =
                scope.ServiceProvider
                    .GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            var userManager =
                scope.ServiceProvider
                    .GetRequiredService<UserManager<ApplicationUser>>();

            await IdentitySeeder.SeedRolesAsync(roleManager);
            await IdentitySeeder.SeedAdminAndEditorAsync(userManager);
        }
    }
}
