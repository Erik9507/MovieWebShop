using MovieWebShop.Repos;
using MovieWebShop.Models;

namespace MovieWebShop.ViewModels
{
    public class CheckOutViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
        //public Customer customer { get; set; }

        public Order order { get; set; }
    }
}
