using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MovieWebShop.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ReleaseYear { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }      
        public int Stock { get; set; }
        public bool IsOnSale { get; set; }
        [AllowNull]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal SalePrice { get; set; }
        public string SaleMessage { get; set; }
        public DateTime SaleStart { get; set; }
        public DateTime SaleEnd { get; set; }
    }
}
