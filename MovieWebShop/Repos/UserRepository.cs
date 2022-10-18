using MovieWebShop.Data;
using MovieWebShop.Interfaces;
using MovieWebShop.Models;

namespace MovieWebShop.Repos
{
    public class UserRepository : IGenericRepo<User>
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User Add(User item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public User Delete(int id)
        {
            var userToDelete = GetById(id);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                _context.SaveChanges();
            }
            return userToDelete;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }

        public User Update(User item, int id)
        {
            var userToUpdate = GetById(id);
            if (userToUpdate != null)
            {
                userToUpdate.UserName = item.UserName;
                userToUpdate.Password = item.Password;
                userToUpdate.IsAdmin = item.IsAdmin;
                _context.SaveChanges();
            }
            return userToUpdate;
        }
    }
}
