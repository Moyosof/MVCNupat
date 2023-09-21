using Microsoft.AspNetCore.Identity;

namespace MVCformNupat
{
    public static class ServiceExtension
    {
        public static async Task EnsureRolesCreatedAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    // Get the RoleManager
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    // Create "Admin" role if it doesn't exist
                    if (!await roleManager.RoleExistsAsync("Admin"))
                    {
                        var adminRole = new IdentityRole
                        {
                            Name = "Admin",
                        };
                        await roleManager.CreateAsync(adminRole);
                    }

                    // Create "User" role if it doesn't exist
                    if (!await roleManager.RoleExistsAsync("User"))
                    {
                        var userRole = new IdentityRole
                        {
                            Name = "User",
                        };
                        await roleManager.CreateAsync(userRole);
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during role creation
                    Console.WriteLine("Error creating roles: " + ex.Message);
                }
            }
        }
    }
}
