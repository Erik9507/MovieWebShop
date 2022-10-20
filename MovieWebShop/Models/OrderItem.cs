using System.ComponentModel.DataAnnotations;

namespace MovieWebShop.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public int MovieId { get; set; }
        public Order order { get; set; }
        
        public Movie movie { get; set; }

        
        
    }
}
