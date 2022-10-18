using MovieWebShop.Data;
using MovieWebShop.Interfaces;
using MovieWebShop.Models;

namespace MovieWebShop.Repos
{
    public class CustomerRepo : IGenericRepo<Customer>
    {
        private readonly AppDbContext _context;
        public CustomerRepo(AppDbContext context)
        {
            _context = context;
        }

        public Customer Add(Customer item)
        {
            _context.Customers.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Customer Delete(int id)
        {
            var customerToDelete = GetById(id);
            if (customerToDelete != null)
            {
                _context.Customers.Remove(customerToDelete);
                _context.SaveChanges();
            }
            return customerToDelete;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public Customer Update(Customer item, int id)
        {
            var customerToUpdate = GetById(id);
            if (customerToUpdate != null)
            {
                customerToUpdate.CustomerName = item.CustomerName;
                customerToUpdate.Address = item.Address;
                customerToUpdate.PhoneNumber = item.PhoneNumber;
                _context.SaveChanges();
            }
            return customerToUpdate;
        }
    }
}
