using MovieWebShop.Data;
using MovieWebShop.Interfaces;
using MovieWebShop.Models;

namespace MovieWebShop.Repos
{
    public class OrderRepo : IOrderRepo
    {
        private readonly AppDbContext _context;
        private readonly ShoppingCartRepo _repo;
        public OrderRepo(AppDbContext context, ShoppingCartRepo repo)
        {
            _context = context;
            _repo = repo;
        }

        public void CreateOrder(Order order)
        {
           order.OrderDate = DateTime.Now;
            order.OrderTotal = _repo.GetTotalPrice();
            _context.Orders.Add(order);
            _context.SaveChanges();

            var shoppingCartItems = _repo.GetShoppingCartItems();
            foreach (var item in shoppingCartItems)
            {
                var orderDetails = new OrderDetail
                {
                    Amount = item.Quantity,
                    Price = item.Movie.Price,
                    movieId = item.Movie.MovieId,
                    OrderId = order.OrderId

                };
                _context.OrderDetails.Add(orderDetails);
            }
            _context.SaveChanges();
        }

    }
}
