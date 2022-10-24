
using Microsoft.AspNetCore.Mvc;
using MovieWebShop.Interfaces;
using MovieWebShop.Models;
using MovieWebShop.Repos;
using MovieWebShop.ViewModels;

namespace MovieWebShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCart _cart;
        private readonly IMovieRepo _movieRepo;

        public ShoppingCartController(ShoppingCart cart, IMovieRepo movieRepo)
        {
            _cart = cart;
            _movieRepo = movieRepo;
        }

        public IActionResult Index()
        {
            _cart.ShoppingCartItems = _cart.GetShoppingCartItems();
            return View(_cart);
        }


        public RedirectToActionResult AddToCart(int id)
        {
            var SelectedMovie = _movieRepo.GetMovies.FirstOrDefault(c => c.MovieId == id);

            if (SelectedMovie != null)
            {
                _cart.AddToCart(SelectedMovie, 1);
            }
            return RedirectToAction("Index", "Movie");
        }

        public RedirectToActionResult AddInCart(int id)
        {
            var SelectedMovie = _movieRepo.GetMovies.FirstOrDefault(c => c.MovieId == id);

            if (SelectedMovie != null)
            {
                _cart.AddToCart(SelectedMovie, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int id)
        {
            var SelectedMovie = _movieRepo.GetMovies.FirstOrDefault(c => c.MovieId == id);

            if (SelectedMovie != null)
            {
                _cart.RemoveFromCart(SelectedMovie);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult ClearCart(string id)
        {
            _cart.ClearCart(id);
            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            _cart.ShoppingCartItems = _cart.GetShoppingCartItems();
            var checkoutViewModel = new CheckOutViewModel
            {
                ShoppingCart = _cart,
                ShoppingCartTotal = _cart.GetTotalPrice(),
                //customer = new Customer()               
            };
            return View(checkoutViewModel);
        }

        public IActionResult CompleteOrder(CheckOutViewModel viewModel)
        {
            Order order = new Order
            {
                OrderDate = DateTime.Now,
                OrderTotal = viewModel.ShoppingCartTotal
            };
            foreach(var item in viewModel.ShoppingCart.ShoppingCartItems)
            {
                order.OrderItems.Add(new OrderItem
                {
                    Quantity = item.Quantity,
                    Price = item.Movie.Price,
                    movie = item.Movie,
                    MovieId = item.Movie.MovieId,
                    OrderId = order.OrderId,
                    order = order,
                });
            }

            return RedirectToAction("CheckoutComplete", "Order");

        }
    }
}
