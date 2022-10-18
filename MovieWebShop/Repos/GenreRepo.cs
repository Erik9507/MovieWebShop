using MovieWebShop.Data;
using MovieWebShop.Interfaces;
using MovieWebShop.Models;

namespace MovieWebShop.Repos
{
    public class GenreRepo : IGenericRepo<Genre>
    {
        private readonly AppDbContext _context;
        public GenreRepo(AppDbContext context)
        {
            _context = context;
        }
        public Genre Add(Genre item)
        {
            _context.Genres.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Genre Delete(int id)
        {
            var genreTodelete = GetById(id);
            if (genreTodelete != null)
            {
                _context.Genres.Remove(genreTodelete);
                _context.SaveChanges();
            }
            return genreTodelete;
        }

        public IEnumerable<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }

        public Genre GetById(int id)
        {
            return _context.Genres.FirstOrDefault(g => g.GenreId == id);
        }

        public Genre Update(Genre item, int id)
        {
            var genreToUpdate = GetById(id);
            if (genreToUpdate != null)
            {
                genreToUpdate.GenreName = item.GenreName;
                _context.SaveChanges();
            }
            return genreToUpdate;
        }
    }
}
