using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieWebShop.Interfaces;
using MovieWebShop.Models;
using MovieWebShop.ViewModels;

namespace MovieWebShop.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepo _repo;
        private readonly IGenericRepo<Genre> _gRepo;

        public MovieController(IMovieRepo repo, IGenericRepo<Genre> gRepo)
        {
            _repo = repo;
            _gRepo = gRepo;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                getMovies = _repo.GetMovies
            };
            return View(homeViewModel);
        }

        public IActionResult Search(string name)
        {
            var homeviewmodel = new HomeViewModel
            {
                getMovies = _repo.GetMovieByName(name)
            };
            return View(homeviewmodel);
        }


        public IActionResult Details(int id)
        {
            var movie = _repo.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }


        public async Task<IActionResult> Edit(int id)
        {
            Movie movie = _repo.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId, Title, Director, ReleaseYear, GenreId, Description, Price, Stock, SalePrice, SaleMessage, IsOnSale, ImageUrl")] Movie movie)
        {
            

            _repo.UpdateMovie(movie, id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            ViewData["GenreID"] = new SelectList(_gRepo.GetAll(), "GenreId", "GenreName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (movie == null) { return BadRequest(); }
            var added = _repo.AddMovie(movie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var movie = _repo.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = _repo.GetMovieById(id);
            if (movie != null)
            {
                _repo.DeleteMovie(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
