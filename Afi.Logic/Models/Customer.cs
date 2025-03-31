using System.ComponentModel.DataAnnotations;

namespace Afi.Logic.Models
{
    public class Customer
    {
        [Required]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Forename { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Policy Reference")]
        [RegularExpression("^[A-Z]{2}\\-[0-9]{6}$", ErrorMessage = "{0} must follow the format: 'XX-999999'.")]
        public string PolicyReference { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateOnly? DateOfBirth { get; set; }

        [Display(Name = "Email Address")]
        public string? EmailAddress { get; set; }
    }
}
