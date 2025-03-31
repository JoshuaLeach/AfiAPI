using Afi.Data.Entities;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace Afi.Data.Interfaces
{
    public interface ICustomerRepository
    {
        int CreateCustomer(Customer customer);
        Customer GetCustomer(int id);
    }
}
