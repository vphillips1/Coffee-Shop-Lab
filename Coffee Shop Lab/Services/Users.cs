using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee_Shop_Lab.Services
{
    public class Users
    {
        //Tried to do the challenge; Create a constructor 
       /* public Users(FormViewModel model)
        {
            var users = new Users(model);
            _coffeeshop.users.add(user);
            var viewModel = new FormResultViewModel();
            viewModel.Users = _coffeeshop.Users;
            return View(viewModel);
        }*/

        //Unable to add my Users class in the Models. It is giving me an error 
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid. Do not use dashes.")]
        public int PhoneNumber { get; set; }

        [Required]
        [Range(18, 150, ErrorMessage = " You have to be at least 18 years or older")]
        public int Age { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please Enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm your password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


    }
}
