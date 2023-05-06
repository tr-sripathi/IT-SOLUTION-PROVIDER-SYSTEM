using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITSolutionProviderSystem.Models
{
    public class FeedbackDetail
    {
        [Required(ErrorMessage = "Please Enter Feedback Detail.")]
        public string Feedback { get; set; }
    } 
}