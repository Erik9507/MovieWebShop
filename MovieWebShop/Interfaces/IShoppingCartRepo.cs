using MovieWebShop.Models;

namespace MovieWebShop.Interfaces
{
    public interface IShoppingCartRepo
    {
        public void AddToCart(Movie movie, int amount);

        public void GetById(int id);
        public int Remove(Movie movie);
        public List<ShoppingcartItems> GetShoppingCartItems();
        public decimal GetTotalPrice();
        public void ClearCart();
    }
}
