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
                // Admin 2

                // Admin
                string adminUserEmail2 = "admin2@autopharma.com";

                var adminUser2 = await userManager.FindByEmailAsync(adminUserEmail2);
                if (adminUser2 == null)
                {
                    var newAdminUser2 = new ApplicationUser()
                    {

                        UserName = "admin-user2",
                        Email = adminUserEmail2,
                        EmailConfirmed = true,
                        PhoneNumber = "123456"

                    };

                    await userManager.CreateAsync(newAdminUser2, "Admin123!");
                    await userManager.AddToRoleAsync(newAdminUser2, Roles.Admin);
                }

                //Pharmacict => Editor

                string editorUserEmail = "Pharmacist@autopharma.com";

                var editorUser = await userManager.FindByEmailAsync(editorUserEmail);
                if (editorUser == null)
                {
                    var newEditorUser = new ApplicationUser()
                    {
                        FullName="Hanan Nathem Saadeh",
                        UserName = "PharmacistUser-user",
                        Email = editorUserEmail,
                        EmailConfirmed = true,
                        BranchId = 1,
                        CityId=1,
                        PhoneNumber= "12345"


                    };
                    await userManager.CreateAsync(newEditorUser, "Pharmacist123!");
                    await userManager.AddToRoleAsync(newEditorUser, Roles.Editor);
                }
                //Pharmacict => Editor

                string editorUserEmail2 = "Pharmacist2@autopharma.com";

                var editorUser2 = await userManager.FindByEmailAsync(editorUserEmail2);
                if (editorUser2 == null)
                {
                    var newEditorUser2 = new ApplicationUser()
                    {
                        FullName = "Shadi Aslan",
                        UserName = "PharmacistUser-user2",
                        Email = editorUserEmail2,
                        EmailConfirmed = true,
                        BranchId =3,
                        CityId = 1,
                        PhoneNumber = "12345"


                    };
                    await userManager.CreateAsync(newEditorUser2, "Pharmacist123!");
                    await userManager.AddToRoleAsync(newEditorUser2, Roles.Editor);
                }
            }
        }
    }
}
