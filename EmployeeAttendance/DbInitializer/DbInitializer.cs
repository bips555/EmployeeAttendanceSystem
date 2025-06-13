using EmployeeAttendance.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendance.DbInitializer
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await context.Database.MigrateAsync();
            await SeedRolesAsync(roleManager);
            await SeedUserAdmin(userManager);
            

        }
        private static async Task SeedRolesAsync(RoleManager<IdentityRole>roleManager)
        {
            string[] Roles = new string[] { "Admin", "Employee" };
            foreach (string role in Roles)

            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
        private static async Task SeedUserAdmin(UserManager<IdentityUser> userManager)
        {
            var adminUser = await userManager.FindByEmailAsync("Admin@gmail.com");
            if(adminUser == null)
            {
                var user = new IdentityUser()
                {
                    UserName = "Admin@gmail.com",
                    Email = "Admin@gmail.com",
                    EmailConfirmed = true

                };
                string password = "Admin@123";
                var createUser =await userManager.CreateAsync(user, password);
                if(createUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(user,"Admin");
                }
            }

        }
    }
}
