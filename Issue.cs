using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITSolutionProviderSystem.Models
{
    public class Issue
    {
        public string ID { get; set; }

        [Display(Name = "Issue Category")]
        [Required(ErrorMessage = "Please Select Issue Category.")]
        public string Issue_Category { get; set; }

        [Display(Name = "Issue Date")]
        [Required(ErrorMessage = "Please Select Issue Date.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string Issue_Date { get; set; }
        public string Priority { get; set; }
        [Required(ErrorMessage = "Please Enter Description.")]
        public string Description { get; set; }
    }
}