using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieWebShop.Data;
using MovieWebShop.Interfaces;
using MovieWebShop.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieWebShop.Repos
{
    public class ShoppingCartRepo //: IShoppingCartRepo
    {
        private readonly AppDbContext _context;
        public string ShoppingCartID { get; set; }
        public List<ShoppingcartItems> ShoppingCartItems { get; set; }
        public ShoppingCartRepo(AppDbContext context)
        {
            _context = context;
        }

        public Order CreateOrder()
        {
            
            Order order = new Order();

            foreach (var item in ShoppingCartItems)
            {
                order.OrderDetails.Add(new OrderDetail { movieId = item.Movie.MovieId, Amount = item.Quantity, Price = item.Movie.Price });
            }
            return order;
        }

        public static ShoppingCartRepo GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartID") ?? Guid.NewGuid().ToString();
            session.SetString("CartID", cartId);

            return new ShoppingCartRepo(context) { ShoppingCartID = cartId };
        }

        
        public void AddToCart(Movie movie, int amount)
        {
            var ShoppingCartItem = _context.ShoppingCartItems.SingleOrDefault
                (c => c.Movie.MovieId == movie.MovieId && c.ShoppingcartId == ShoppingCartID);
            if (movie.Stock >= 1)
            {
                if (ShoppingCartItem == null)
                {

                    ShoppingCartItem = new ShoppingcartItems
                    {
                        ShoppingcartId = ShoppingCartID,
                        Movie = movie,
                        Quantity = amount,

                    };
                    ShoppingCartItem.Movie.Stock--;
                    _context.ShoppingCartItems.Add(ShoppingCartItem);

                }

                else
                {
                    ShoppingCartItem.Movie.Stock--;
                    ShoppingCartItem.Quantity++;
                }
            }

            _context.SaveChanges();
        }

        public void ClearCart(string id)
        {
            var itemsInCart = _context.ShoppingCartItems.Include(m => m.Movie).Where(s => s.ShoppingcartId == id).ToList();
            foreach (var item in itemsInCart)
            {
                item.Movie.Stock = item.Movie.Stock + item.Quantity;
            }
            var cartItems = _context.ShoppingCartItems.Where(c => c.ShoppingcartId == ShoppingCartID);
            _context.ShoppingCartItems.RemoveRange(cartItems);

            _context.SaveChanges();
        }


        public List<ShoppingcartItems> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = (List<ShoppingcartItems>?)_context.ShoppingCartItems
                .Where(s => s.ShoppingcartId == ShoppingCartID).Include(m => m.Movie).ToList());
        }

        public decimal GetTotalPrice()
        {
            var total = _context.ShoppingCartItems.Where(c => c.ShoppingcartId == ShoppingCartID)
                .Select(c => c.Movie.Price * c.Quantity).Sum();

            return total;
        }

        public int RemoveFromCart(Movie movie)
        {
            var ShoppingCartItem = _context.ShoppingCartItems.SingleOrDefault
                (c => c.Movie.MovieId == movie.MovieId && c.ShoppingcartId == ShoppingCartID);

            var localAmount = 0;

            if (ShoppingCartItem != null)
            {
                if (ShoppingCartItem.Quantity > 1)
                {
                    ShoppingCartItem.Quantity--;
                    localAmount = ShoppingCartItem.Quantity;

                }
                else
                {
                    _context.ShoppingCartItems.Remove(ShoppingCartItem);
                }
                ShoppingCartItem.Movie.Stock++;
            }
            _context.SaveChanges();
            return localAmount;
        }


    }
}
