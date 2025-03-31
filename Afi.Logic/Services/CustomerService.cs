using Afi.Data.Interfaces;
using Afi.Data.Repositories;
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
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ILogger<ICustomerService> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        public int RegisterCustomer(Customer customer)
        {
            ValidateCustomer(customer);

            Data.Entities.Customer validatedCustomer = new Data.Entities.Customer()
            {
                DateOfBirth = customer.DateOfBirth,
                EmailAddress = customer.EmailAddress,
                Forename = customer.Forename,
                PolicyReference = customer.PolicyReference,
                Surname = customer.Surname,
            };

            var id = _customerRepository.CreateCustomer(validatedCustomer);
            return id;
        }
        
        public Customer GetCustomer(int id)
        {
            var customer = _customerRepository.GetCustomer(id);

            Customer retrievedCustomer = new Customer()
            {
                DateOfBirth = customer.DateOfBirth,
                EmailAddress = customer.EmailAddress,
                Forename = customer.Forename,
                PolicyReference = customer.PolicyReference,
                Surname = customer.Surname,
            };

            return retrievedCustomer;
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
