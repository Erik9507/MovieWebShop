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
            modelBuilder.Entity<Genre>().HasData(new Genre { GenreId = 1, GenreName = "Comedy" });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            { Id = "9fa474d4-0246-47db-834e-5b44c2d3ae19", Name = "User", NormalizedName = "USER" });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            { Id = "d49bc437-f9e7-41c4-be19-c17ad1691612", Name = "Admin", NormalizedName = "ADMIN" });



        }
    }
}
