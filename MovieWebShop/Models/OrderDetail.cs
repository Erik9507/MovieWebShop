using System.ComponentModel.DataAnnotations;

namespace MovieWebShop.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Order order { get; set; }
        public int movieId { get; set; }
        public Movie movie { get; set; }

        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
