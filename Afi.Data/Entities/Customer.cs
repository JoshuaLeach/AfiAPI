using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afi.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string PolicyReference { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? EmailAddress { get; set; }
    }
}
