//using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWebShop.Interfaces;
using MovieWebShop.Models;
using MovieWebShop.ViewModels;

namespace MovieWebShop.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepo _repo;

        public MovieController(IMovieRepo repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                getMovies = _repo.GetMovies
            };
            return View(homeViewModel);
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
        public async Task<IActionResult> Edit(int id, [Bind("MovieId, Title, Director, ReleaseYear, GenreId, Description, Price, Stock")] Movie movie)
        {

            _repo.UpdateMovie(movie, id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (movie == null) { return BadRequest(); }
            var added = _repo.AddMovie(movie);
            return RedirectToAction(nameof(Index));
            //return CreatedAtAction(nameof(Details), new { id = added.MovieId }, added);
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
