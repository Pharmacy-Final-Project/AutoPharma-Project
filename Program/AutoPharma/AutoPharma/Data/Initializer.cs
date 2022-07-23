using AutoPharma.Auth.Model;
using AutoPharma.Data.Static;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace AutoPharma.Data
{
    public class Initializer
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync(Roles.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
                }

                if (!await roleManager.RoleExistsAsync(Roles.Editor))
                {
                    await roleManager.CreateAsync(new IdentityRole(Roles.Editor));
                }
                if (!await roleManager.RoleExistsAsync(Roles.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(Roles.User));
                }
                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                // Admin
                string adminUserEmail = "admin@autopharma.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {

                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        PhoneNumber = "123456"

                    };

                    await userManager.CreateAsync(newAdminUser, "Admin123!");
                    await userManager.AddToRoleAsync(newAdminUser, Roles.Admin);
                }
                //Pharmacict => Editor

                string editorUserEmail = "Pharmacist@autopharma.com";

                var editorUser = await userManager.FindByEmailAsync(editorUserEmail);
                if (editorUser == null)
                {
                    var newEditorUser = new PharmacistUser()
                    {

                        UserName = "PharmacistUser-user",
                        Email = editorUserEmail,
                        EmailConfirmed = true,
                        BranchId = 1,
                        CityId = 1,
                        PhoneNumber = "12345"


                    };
                    await userManager.CreateAsync(newEditorUser, "Pharmacist123!");
                    await userManager.AddToRoleAsync(newEditorUser, Roles.Editor);


                    string appUserEmail = "User@autopharma.com";

                    var appUser = await userManager.FindByEmailAsync(appUserEmail);
                    if (appUser == null)
                    {
                        var newAppUser = new ApplicationUser()
                        {
                            FullName = "Application User",
                            UserName = "app-user",
                            Email = appUserEmail,
                            EmailConfirmed = true
                        };
                        await userManager.CreateAsync(newAppUser, "User123!");
                        await userManager.AddToRoleAsync(newAppUser, Roles.User);
                    }
                }
            }
        }
    }
}
