using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITSolutionProviderSystem.Models
{
    public class SolutionDetail
    {
        [Required(ErrorMessage = "Please Enter Solution.")]
        public string Solution { get; set; }
        public string Status { get; set; }
    }
}