using InfrastructureLayer.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Identity
{
    public class IdentitySeeder
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole<Guid>> roleManager)
        {
            string[] roles = { "Admin", "Editor", "Reader" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole<Guid>
                    {
                        Name = role,

                    });
                }
            }
        }
        public static async Task SeedAdminAndEditorAsync(UserManager<ApplicationUser> userManager)
        {
            var adminEmail = "admin@blog.com";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = "admin",
                    Email = adminEmail,
                    FullName = "System Admin"

                };

                var result = await userManager.CreateAsync(adminUser, "Admin@123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }


            var editorEmail = "editor@blog.com";

            var editorUser = await userManager.FindByEmailAsync(editorEmail);

            if (editorUser == null)
            {
                editorUser = new ApplicationUser
                {
                    UserName = "editor",
                    Email = editorEmail,
                    FullName = "System Editor",

                };

                var result = await userManager.CreateAsync(editorUser, "Editor@123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(editorUser, "Editor");
                }

            }
        }
    }
}
