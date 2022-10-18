using MovieWebShop.Data;
using MovieWebShop.Interfaces;
using MovieWebShop.Models;

namespace MovieWebShop.Repos
{
    public class ShoppingCartItemRepo : IGenericRepo<ShoppingcartItems>
    {
        private readonly AppDbContext _context;
        public ShoppingCartItemRepo(AppDbContext context)
        {
            _context = context;
        }

        public ShoppingcartItems Add(ShoppingcartItems item)
        {
            
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public ShoppingcartItems Delete(int id)
        {
            var itemToDelete = GetById(id);
            if (itemToDelete != null)
            {
                _context.ShoppingCartItems.Remove(itemToDelete);
                _context.SaveChanges();
            }
            return itemToDelete;
        }

        public IEnumerable<ShoppingcartItems> GetAll()
        {
            return _context.ShoppingCartItems.ToList();
        }

        public ShoppingcartItems GetById(int id)
        {
            return _context.ShoppingCartItems.FirstOrDefault(s => s.ItemId == id);
        }

        public ShoppingcartItems Update(ShoppingcartItems item, int id)
        {
            var cartToUpdate = GetById(id);
            if (cartToUpdate != null)
            {
                cartToUpdate.Quantity = item.Quantity;
                cartToUpdate.ShoppingcartId = item.ShoppingcartId;
                cartToUpdate.Movie.MovieId = item.Movie.MovieId;
                _context.SaveChanges();
            }
            return cartToUpdate;
        }
    }
}
