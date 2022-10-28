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

            //this.SeedUsers(modelBuilder);
            //this.SeedUserRoles(modelBuilder);
            //this.SeedRoles(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "a17a5bbe-6f3f-44af-855c-28ec50eceb2d",
                Name ="Admin",
                NormalizedName = "Admin"
            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "efd2b503-4910-48d4-903b-16ef0285418b",
                Name ="User",
                NormalizedName ="USER"
            });
            var hasher = new PasswordHasher<IdentityUser>();
            var passHash = hasher.HashPassword(null, "Admin111!");

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "ce02a491-dec2-4e08-936a-e64dd8ad72e1",
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
                PasswordHash = passHash
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = "ce02a491-dec2-4e08-936a-e64dd8ad72e1",
                RoleId = "a17a5bbe-6f3f-44af-855c-28ec50eceb2d"
            });

        }
        //private void SeedUsers(ModelBuilder builder)
        //{
        //    IdentityUser user = new IdentityUser()
        //    {
        //        Id = "b74ddd14-6340-4840-95c2-db12554843e5",
        //        UserName = "Admin",
        //        Email = "admin@gmail.com",
        //        LockoutEnabled = false,
        //        PhoneNumber = "1234567890"
        //    };

        //    PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
        //    passwordHasher.HashPassword(user, "Admin123!");

        //    builder.Entity<IdentityUser>().HasData(user);
        //}

        //private void SeedRoles(ModelBuilder builder)
        //{
        //    builder.Entity<IdentityRole>().HasData(
        //        new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
        //        new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "User", ConcurrencyStamp = "2", NormalizedName = "USER" }
        //        );
        //}

        //private void SeedUserRoles(ModelBuilder builder)
        //{
        //    builder.Entity<IdentityUserRole<string>>().HasData(
        //        new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
        //        );
        //}
    }
}
