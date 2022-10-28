using Microsoft.AspNetCore.Identity;

namespace MovieWebShop.Data
{
    public class SampleData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var adminRole = new IdentityRole
            {
                Id = "d49bc437-f9e7-41c4-be19-c17ad1691612",
                Name = "Admin",
                NormalizedName = "ADMIN"
            };
            var userRole = new IdentityRole
            {
                Id = "9fa474d4-0246-47db-834e-5b44c2d3ae19",
                Name = "User",
                NormalizedName = "USER"
            };
            var hasher = new PasswordHasher<IdentityUser>();
            var user = new IdentityUser
            {
                Id = "f3af40ad-1031-4f69-ba90-c628cbcefcd8",
                UserName = "admin@test.se",
                NormalizedUserName = "ADMIN@TEST.SE",
                Email = "admin@test.se",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                NormalizedEmail = "ADMIN@TEST.SE",
                SecurityStamp = "Admin",
                PasswordHash = hasher.HashPassword(null, "Admin111!")
            };
            var userRoles = new IdentityUserRole<string>
            {
                UserId = "f3af40ad-1031-4f69-ba90-c628cbcefcd8",
                RoleId = "d49bc437-f9e7-41c4-be19-c17ad1691612"
            };
            context.Roles.Add(adminRole);
            context.Roles.Add(userRole);
            context.Users.Add(user);
            context.UserRoles.Add(userRoles);
            context.SaveChanges();

        }
        public static void SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("admin@test.se").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.Id = "f3af40ad-1031-4f69-ba90-c628cbcefcd8";
                user.UserName = "admin@test.se";
                user.NormalizedUserName = "ADMIN@TEST.SE";
                user.Email = "admin@test.se";
                user.EmailConfirmed = true;
                user.PhoneNumberConfirmed = true;
                user.TwoFactorEnabled = false;
                user.LockoutEnabled = false;
                user.AccessFailedCount = 0;
                user.NormalizedEmail = "ADMIN@TEST.SE";
                user.SecurityStamp = "Admin";

                IdentityResult result = userManager.CreateAsync
                (user, "Password100!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

    }
}
