using Microsoft.EntityFrameworkCore;
using MovieWebShop.Data;
using MovieWebShop.Interfaces;
using MovieWebShop.Models;

namespace MovieWebShop.Repos
{
    public class OrderRepo : IOrderRepo
    {
        private readonly AppDbContext _context;
        private readonly ShoppingCart _cart;
        public OrderRepo(AppDbContext context, ShoppingCart repo)
        {
            _context = context;
            _cart = repo;
        }

        public void CreateOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            var cartItems = _cart.ShoppingCartItems;

            foreach (var item in cartItems)
            {
                var orderItem = new OrderItem()
                {
                    Quantity = item.Quantity,
                    MovieId = item.MovieId,
                    OrderId = order.OrderId
                    //Price = item.Movie.Price * item.Quantity
                };

                if (item.Movie.IsOnSale)
                {
                    orderItem.Price = item.Movie.SalePrice;
                }
                else
                {
                    orderItem.Price = item.Movie.Price;
                }

                order.OrderItems.Add(orderItem);
                order.OrderTotal += orderItem.Price * item.Quantity;
            }
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var orders = _context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.movie).ToList();
            orders.Reverse();
            return orders;
        }
    }
}
