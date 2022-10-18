using System.ComponentModel.DataAnnotations;

namespace MovieWebShop.Models
{
    public class ShoppingcartItems
    {
        [Key]
        public int ItemId { get; set; }
        public string ShoppingcartId { get; set; }
        public Movie Movie { get; set; }
        public int Quantity { get; set; }
    }
}
