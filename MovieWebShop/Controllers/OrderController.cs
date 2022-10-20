using Microsoft.AspNetCore.Mvc;
using MovieWebShop.Interfaces;
using MovieWebShop.Models;
using MovieWebShop.Repos;
using MovieWebShop.ViewModels;
using System.Runtime.CompilerServices;

namespace MovieWebShop.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderRepo _repo;
        private readonly ShoppingCart _cart;

        public OrderController(IOrderRepo repo, ShoppingCart cartRepo)
        {
            _repo = repo;
            _cart = cartRepo;
        }
        public IActionResult Index()
        {
            OrdersViewModel viewModel = new OrdersViewModel
            {
                orders = _repo.GetAllOrders()
            };          
            return View(viewModel);
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _cart.ShoppingCartItems = _cart.GetShoppingCartItems();
            if (_cart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Cart is empty, please add a movie to your cart first.");
            }

            if (ModelState.IsValid)
            {
                _repo.CreateOrder(order);
                _cart.ClearCart(_cart.ShoppingCartID);
                return View("CheckoutComplete", order);
            }
            return View(order);
        }

        public IActionResult CheckOutComplete(Order order)
        {
           return View(order);
        }

    }
}
