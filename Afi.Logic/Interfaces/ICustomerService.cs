using Afi.Logic.Models;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace Afi.Logic.Services
{
    public interface ICustomerService
    {
        int RegisterCustomer(Customer customer);
        void ValidateCustomer(Customer customer);

    }
}
