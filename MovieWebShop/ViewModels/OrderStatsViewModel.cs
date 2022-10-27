using MovieWebShop.Models;

namespace MovieWebShop.ViewModels
{
	public class OrderStatsViewModel
	{
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Movie> Movies { get; set; }

    }
}
