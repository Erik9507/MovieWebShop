using MovieWebShop.Models;

namespace MovieWebShop.Interfaces
{
    public interface IMovieRepo
    {
        IEnumerable<Movie> GetMovies { get; }
        public Movie GetMovieById(int id);
        public Movie GetMovieByName(string name);
        public IEnumerable<Movie> GetMoviesByGenre(int genreId);
        public Movie AddMovie(Movie movie);
        public Movie UpdateMovie(Movie movie, int id);
        public Movie DeleteMovie(int id);
    }
}
