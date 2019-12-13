using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MijiKalaWebApp.Classes
{
    public class DataSeeder
    {
        public static void SeedAuthData(IApplicationBuilder app)
        {
            SeedRoles(app);
            SeedUsers(app);
        }

        public static void SeedRoles(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var manager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>())
                {
                    if (manager.Roles.Any())
                        return;

                    var roles = typeof(RolesConst).GetFields(BindingFlags.Static | BindingFlags.Public)
                        .Select(i => i.GetValue(null)).OfType<string>();

                    foreach (var role in roles)
                        manager.CreateAsync(new IdentityRole<Guid>(role)).Wait();
                }
            }
        }

        public static void SeedUsers(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var manager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser<Guid>>>())
                {
                    if (manager.Users.Any())
                        return;

                    var userProfileRepository = scope.ServiceProvider.GetRequiredService<UserProfileRepository>();

                    var admin = new IdentityUser<Guid>()
                    {
                        Id = Guid.NewGuid(),
                        Email = "admin@Shop.ir",
                        UserName = "admin"
                    };
                    manager.CreateAsync(admin, "12345").Wait();
                    manager.AddToRoleAsync(admin, AppRoles.Administrator).Wait();
                    manager.AddClaimAsync(admin, new Claim(AppClaims.FullName, "علیرضا عماری")).Wait();
                    userProfileRepository.RegisterUserProfileAsync(new UserProfileDto()
                    {
                        UserId = admin.Id,
                        FirstName = "علیرضا",
                        LastName = "عماری",
                    }).Wait();
                    var user = new IdentityUser<Guid>()
                    {
                        Id = Guid.NewGuid(),
                        Email = "user@Shop.ir",
                        UserName = "user"
                    };
                    manager.CreateAsync(user, "12345").Wait();
                    manager.AddToRoleAsync(user, AppRoles.Customer).Wait();
                    manager.AddClaimAsync(user, new Claim(AppClaims.FullName, "آرمین احمدی")).Wait();
                    userProfileRepository.RegisterUserProfileAsync(new UserProfileDto()
                    {
                        UserId = user.Id,
                        FirstName = "آرمین",
                        LastName = "احمدی",
                    }).Wait();
                }
            }
        }
    }
}
