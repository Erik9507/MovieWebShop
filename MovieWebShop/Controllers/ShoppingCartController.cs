
using Microsoft.AspNetCore.Mvc;
using MovieWebShop.Interfaces;
using MovieWebShop.Models;
using MovieWebShop.Repos;
using MovieWebShop.ViewModels;

namespace MovieWebShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCartRepo _cartRepo;
        private readonly IMovieRepo _movieRepo;

        public ShoppingCartController(ShoppingCartRepo cartRepo, IMovieRepo movieRepo)
        {
            _cartRepo = cartRepo;
            _movieRepo = movieRepo;
        }

        public IActionResult Index()
        {
            _cartRepo.ShoppingCartItems = _cartRepo.GetShoppingCartItems();
            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _cartRepo,
                ShoppingCartTotal = _cartRepo.GetTotalPrice()

            };
            return View(shoppingCartViewModel);
        }


        public RedirectToActionResult AddToCart(int id)
        {
            var SelectedMovie = _movieRepo.GetMovies.FirstOrDefault(c => c.MovieId == id);

            if (SelectedMovie != null)
            {
                _cartRepo.AddToCart(SelectedMovie, 1);
            }
            return RedirectToAction("Index", "Movie");
        }

        public RedirectToActionResult AddInCart(int id)
        {
            var SelectedMovie = _movieRepo.GetMovies.FirstOrDefault(c => c.MovieId == id);

            if (SelectedMovie != null)
            {
                _cartRepo.AddToCart(SelectedMovie, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int id)
        {
            var SelectedMovie = _movieRepo.GetMovies.FirstOrDefault(c => c.MovieId == id);

            if (SelectedMovie != null)
            {
                _cartRepo.RemoveFromCart(SelectedMovie);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult ClearCart(string id)
        {
            _cartRepo.ClearCart(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateOrder()
        {
            Order order = _cartRepo.CreateOrder();

            return View(order);
        }

    }
}
