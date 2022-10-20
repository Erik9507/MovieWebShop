using Microsoft.EntityFrameworkCore;
using MovieWebShop.Data;
using MovieWebShop.Interfaces;
using MovieWebShop.Models;

namespace MovieWebShop.Repos
{
    public class MovieRepo : IMovieRepo
    {
        private readonly AppDbContext _context;

        public MovieRepo(AppDbContext context)
        {
            _context = context;
        }

        public Movie AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        public Movie DeleteMovie(int id)
        {
            var movieToDelete = GetMovieById(id);
            if (movieToDelete != null)
            {
                _context.Remove(movieToDelete);
                _context.SaveChanges();
            }
            return movieToDelete;
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.Include(x => x.Genre).FirstOrDefault(x => x.MovieId == id);
        }

        public Movie GetMovieByName(string name)
        {
            return _context.Movies.Include(x => x.Genre).FirstOrDefault(m => m.Title == name);
        }

        public IEnumerable<Movie> GetMovies
        {
            get
            {
                return _context.Movies.Include(x => x.Genre);
            }
        }


        public IEnumerable<Movie> GetMoviesByGenre(int genreId)
        {
            return _context.Movies.Include(x => x.Genre).Where(m => m.GenreId == genreId).ToList();
        }

        public Movie UpdateMovie(Movie movie, int id)
        {
            Movie movieToUpdate = GetMovieById(id);
            if (movieToUpdate != null)
            {
                movieToUpdate.Title = movie.Title;
                movieToUpdate.Director = movie.Director;
                movieToUpdate.Description = movie.Description;
                movieToUpdate.Stock = movie.Stock;
                movieToUpdate.Price = movie.Price;
                movieToUpdate.ReleaseYear = movie.ReleaseYear;
                movieToUpdate.GenreId = movie.GenreId;
                movieToUpdate.SaleMessage = movie.SaleMessage;
                movieToUpdate.SalePrice = movie.SalePrice;
                movieToUpdate.IsOnSale = movie.IsOnSale;
                _context.SaveChanges(); 
                return movieToUpdate;
            }
            return null;
            
        }
    }
}
