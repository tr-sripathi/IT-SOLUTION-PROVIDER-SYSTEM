using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ITSolutionProviderSystem.Models
{
    public class Login
    {
            [Display(Name = "Email :")]
            [Required(ErrorMessage = "Please Enter Email Id.")]
            [EmailAddress(ErrorMessage = "Invalid Email Address")]
            public string Email { get; set; }

            [Display(Name = "Password :")]
            [Required(ErrorMessage = "Password is required.")]
            [DataType(DataType.Password)]
            public string password { get; set; }
    }
}