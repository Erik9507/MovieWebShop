using Microsoft.EntityFrameworkCore;
using MovieWebShop.Models;
using System.Collections.Generic;

namespace MovieWebShop.Data
{
    public class AppDbContext : DbContext
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
        }
    }
}
