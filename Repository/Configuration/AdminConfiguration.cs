using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Repository.Configuration
{
    public static class AdminConfiguration
    {
        public static async Task Initialize(IServiceCollection services)
        {
            using (var serviceProvider = services.BuildServiceProvider())
            using (var scope = serviceProvider.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

                // Seed roles
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new Role("Admin"));
                }

                // Seed admin user
                var adminUser = new User
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com"
                    // Set other properties of the admin user
                };

                var password = "AdminPassword123"; // Set the desired password

                if (await userManager.FindByEmailAsync(adminUser.Email) == null)
                {
                    var result = await userManager.CreateAsync(adminUser, password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                }
            }
        }
    }
}
