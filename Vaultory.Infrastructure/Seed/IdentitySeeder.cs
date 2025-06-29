using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Vaultory.Infrastructure.Identity;

namespace Vaultory.Infrastructure.Seed;

public class IdentitySeeder
{
    public async static Task SeedRolesAndSuperAdminAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        string[] roles = { "Admin", "Manager", "User" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        var adminEmail = "admin@vaultory.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            var user = new ApplicationUser
            {
                UserName = "superadmin",
                Email = adminEmail,
                EmailConfirmed = true

            };

            var result = await userManager.CreateAsync(user, "Vaultory@123");

            if (result.Succeeded) await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}