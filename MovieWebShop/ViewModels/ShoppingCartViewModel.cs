using MovieWebShop.Models;
using MovieWebShop.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebShop.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartRepo ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
