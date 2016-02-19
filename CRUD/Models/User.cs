using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [Display(Name = "First name")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Entered first name is not valid.")]
        public string FirstName { get; set;}

        [Required]
        [Display(Name = "Last name")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Entered last name is not valid.")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Entered phone number format is not valid.")]
        [Display(Name = "Phone number (000-000-000)")]
        public string TelephoneNumber { get; set; }

        
        public User()
        {
            //empty
        }

        
        public User(string firstName, string lastName, string email, string telephoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            TelephoneNumber = telephoneNumber;
        }
    }
}