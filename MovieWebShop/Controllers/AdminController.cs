using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieWebShop.Data;
using MovieWebShop.Interfaces;
using MovieWebShop.Models;
using MovieWebShop.ViewModels;

namespace MovieWebShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IMovieRepo _movieRepo;


        public AdminController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IMovieRepo movieRepo)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._movieRepo = movieRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// 
        /// METHODS FOR USER MANAGEMENT
        ///
        public IActionResult ListUsers()
        {
            var users = userManager.Users;
            return View(users);
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = model.Email, Email = model.Email };
                user.EmailConfirmed = true;
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with id: {id} was not found";
                return View("NotFound");
            }
            var model = new EditUserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
                //,
                //Password = user.Pa
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with id: {model.Id} was not found";
                return View("NotFound");
            }
            else
            {
                user.UserName = model.UserName;
                user.Email = model.Email;


                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }

        }
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with id: {id} was not found";
                return View("NotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("ListUsers");
            }
        }
        /// 
        /// METHODS FOR MOVIE MANAGEMENT
        ///
        public IActionResult ListMovies()
        {
            var movies = _movieRepo.GetMovies.ToList();
            return View(movies);
        }
        [HttpGet]
        public IActionResult RegisterMovie()
        {
            return View();
        }
        public async Task<IActionResult> RegisterMovie(Movie movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }
            //if (ModelState.IsValid)
            //{
            //    var added = _movieRepo.AddMovie(movie);
            //}
            var added = _movieRepo.AddMovie(movie);
            return RedirectToAction("ListMovies");
        }
        [HttpGet]
        public async Task<IActionResult> EditMovie(int id)
        {
            Movie movie = _movieRepo.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }
        [HttpPost]
        public async Task<IActionResult> EditMovie(int id, [Bind("MovieId, Title, Director, ReleaseYear, GenreId, Description, Price, Stock, SalePrice, SaleMessage, IsOnSale, ImageUrl")] Movie movie)
        {
            _movieRepo.UpdateMovie(movie, id);
            return RedirectToAction("ListMovies");
        }

        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var movie = _movieRepo.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }
        //[HttpPost, ActionName("DeleteMovie")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = _movieRepo.GetMovieById(id);
            if (movie != null)
            {
                _movieRepo.DeleteMovie(id);
            }
            return RedirectToAction("ListMovies");
        }
    }
}
