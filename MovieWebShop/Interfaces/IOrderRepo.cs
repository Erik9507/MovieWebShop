using MovieWebShop.Models;

namespace MovieWebShop.Interfaces
{
    public interface IOrderRepo
    {
        void CreateOrder(Order order);
    }
}
