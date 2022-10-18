using Microsoft.AspNetCore.Mvc;
using MovieWebShop.Interfaces;
using MovieWebShop.Models;
using MovieWebShop.Repos;
using System.Runtime.CompilerServices;

namespace MovieWebShop.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderRepo _repo;
        private readonly ShoppingCartRepo _cartRepo;

        public OrderController(IOrderRepo repo, ShoppingCartRepo cartRepo)
        {
            _repo = repo;
            _cartRepo = cartRepo;
        }

        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            _cartRepo.ShoppingCartItems = _cartRepo.GetShoppingCartItems();
            if (_cartRepo.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Cart Empty");
            }
            if (ModelState.IsValid)
            {
                _repo.CreateOrder(order);
                //_cartRepo.ClearCart(); gör ny metod
                return RedirectToAction("CheckOutComplete");
            }
            return View(order);
        }

        public IActionResult CheckOutComplete()
        {
            ViewBag.CheckOutCompleteMessage = "Thank you for your order";
            return View();
        }

    }
}
