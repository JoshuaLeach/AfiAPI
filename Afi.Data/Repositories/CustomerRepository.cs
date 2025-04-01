using Afi.Data.Entities;
using Afi.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace Afi.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        { 
            _context = context;
        }

        public int CreateCustomer(Customer customer)
        { 
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer.Id;
        }

        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.Where(c => c.Id == id).FirstOrDefault();
            return customer;
        }
    }
}
