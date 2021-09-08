using System;
using System.ComponentModel.DataAnnotations;

namespace Contacts.DB
{
    public class Contact
    {
        [Required(ErrorMessage = "ID number is required")]
        [RegularExpression("^\\d{9}$", ErrorMessage = "ID contains exactly 9 digits")]
        public string ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of birth number is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; } 

        public string Gender { get; set; }

        [RegularExpression("^\\d{10}$", ErrorMessage = "Phone number contains exactly 10 digits")]
        public string PhoneNumber { get; set; }
    }
}
