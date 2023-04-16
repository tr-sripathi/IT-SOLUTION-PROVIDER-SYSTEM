using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ITSolutionProviderSystem.Models
{
    public class RegistrationDetails
    {
        //[Display(Name = "User Name :")]
        //[Required(ErrorMessage = "Please Enter User Name.")]
        //public string Name { get; set; }
        public string UserID { get; set; }

        [Display(Name = "First Name :")]
        [Required(ErrorMessage = "Please Enter First Name.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name :")]
        [Required(ErrorMessage = "Please Enter Last Name.")]
        public string LastName { get; set; }

        [Display(Name = "Email :")]
        [Required(ErrorMessage = "Please Enter Email Id.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Phone no. :")]
        [Required(ErrorMessage = "Please Enter Phone no.")]
        public string Phone { get; set; }

        [Display(Name = "Password :")]
        [Required(ErrorMessage = "Please Enter Password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password :")]
        [Required(ErrorMessage = "Please Enter Confirm Password.")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        public string CPassword { get; set; }

        [Display(Name = "Role :")] 
        public String Roles { get; set; } 
    } 
}