using Afi.Logic.Models;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace Afi.Logic.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<ICustomerService> _logger;

        public CustomerService(ILogger<ICustomerService> logger)
        {
            _logger = logger;
        }

        public int RegisterCustomer(Customer customer)
        {
            ValidateCustomer(customer);
            return 4;
        }

        public void ValidateCustomer(Customer customer)
        {
            if (customer.EmailAddress != null)
            {
                // Validate email address
                if (!Regex.IsMatch(customer.EmailAddress, @"^[a-zA-Z]{4,}\@[a-zA-Z]{2,}\.(com|co\.uk)$"))
                {
                    throw new ValidationException("Email address not valid.");
                };
            }
            else if (customer.DateOfBirth != null)
            {
                // Validate DoB
                DateOnly today = DateOnly.FromDateTime(DateTime.Now);
                int age = today.Year - customer.DateOfBirth.Value.Year;

                // Adjust if birthday hasn't occurred yet this year
                if (today < customer.DateOfBirth.Value.AddYears(age))
                {
                    age--; 
                }

                if (age < 18)
                {
                    throw new ValidationException("Date of birth must be greater than or equal to 18.");
                }
            }
            else
            {
                throw new ValidationException("Must provide either: email address, date of birth.");
            }
            
        }
    }
}
