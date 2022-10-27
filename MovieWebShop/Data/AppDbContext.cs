using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieWebShop.Models;
using System.Collections.Generic;

namespace MovieWebShop.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingcartItems> ShoppingCartItems { get; set; }
        public DbSet<OrderItem> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //SeedRoles(modelBuilder);
            //SeedAdminUser(modelBuilder);
            //SeedUserRole(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            { Id = "9fa474d4-0246-47db-834e-5b44c2d3ae19", Name = "User", NormalizedName = "USER" });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            { Id = "d49bc437-f9e7-41c4-be19-c17ad1691612", Name = "Admin", NormalizedName = "ADMIN" });

            var hasher = new PasswordHasher<IdentityUser>();
            var passwordHash = hasher.HashPassword(null, "Admin111!");

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
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
                PasswordHash = passwordHash
            });

            //IdentityUser admin = new IdentityUser();
            //admin.Id = "f3af40ad-1031-4f69-ba90-c628cbcefcd8";
            //admin.UserName = "admin@test.se";
            //admin.NormalizedUserName = "ADMIN@TEST.SE";
            //admin.Email = "admin@test.se";
            //admin.EmailConfirmed = true;
            //admin.PhoneNumberConfirmed = true;
            //admin.TwoFactorEnabled = false;
            //admin.LockoutEnabled = false;
            //admin.AccessFailedCount = 0;
            //admin.NormalizedEmail = "ADMIN@TEST.SE";
            //admin.SecurityStamp = "Admin";
            ////admin.PasswordHash = passwordHash;

            //PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            //admin.PasswordHash = ph.HashPassword(admin, "Admin111!");

            //modelBuilder.Entity<IdentityUser>().HasData(admin);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "d49bc437-f9e7-41c4-be19-c17ad1691612",
                UserId = "f3af40ad-1031-4f69-ba90-c628cbcefcd8"
            });
        }
        
        public void SeedAdminUser(ModelBuilder mB)
        {

            var hasher = new PasswordHasher<IdentityUser>();
            var passwordHash = hasher.HashPassword(null, "Admin111!");

            mB.Entity<UserManager<IdentityUser>>().HasData(new IdentityUser
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
                PasswordHash = passwordHash
            });

            //IdentityUser admin = new IdentityUser();
            //admin.Id = "f3af40ad-1031-4f69-ba90-c628cbcefcd8";
            //admin.UserName = "admin@test.se";
            //admin.NormalizedUserName = "ADMIN@TEST.SE";
            //admin.Email = "admin@test.se";
            //admin.EmailConfirmed = true;
            //admin.PhoneNumberConfirmed = true;
            //admin.TwoFactorEnabled = false;
            //admin.LockoutEnabled = false;
            //admin.AccessFailedCount = 0;
            //admin.NormalizedEmail = "ADMIN@TEST.SE";
            //admin.SecurityStamp = "Admin";
            ////admin.PasswordHash = passwordHash;

            //mB.Entity<UserManager<IdentityUser>>().HasData(admin);

            ////IdentityResult result = userManager.CreateAsync(admin, "Admin111!").Result;

            ////if (result.Succeeded)
            ////{
            ////    userManager.AddToRoleAsync(admin, "Admin").Wait();
            ////}
        }
        public void SeedUserRole(ModelBuilder mB)
        {
            mB.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "d49bc437-f9e7-41c4-be19-c17ad1691612",
                UserId = "f3af40ad-1031-4f69-ba90-c628cbcefcd8"
            });
        }
    }
}
