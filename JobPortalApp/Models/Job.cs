using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortalApp.Models
{
    public class Job
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter title")]
        
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter company")]
        public string Company { get; set; }
        [Required(ErrorMessage = "Please enter description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter lase date to apply")]
        [DisplayName("Last date to apply")]
        public string LastDateToApply { get; set; }
        [DisplayName("Number of post")]
        [Required(ErrorMessage = "Please enter number of post")]
        public int NumberOfPost { get; set; }
        [Required(ErrorMessage = "Please enter Qualification")]
        public string Qualification { get; set; }
        
        [Required(ErrorMessage = "Please enter experience")]
        public string Experience { get; set; }
        [Required(ErrorMessage = "Please enter location")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Please enter Responsibilities")]
        public string Responsibilities { get; set; }
        [Required(ErrorMessage = "Please enter salary")]
        public string Salary { get; set; }
        
        [Required(ErrorMessage = "Please select job type")]

        [DisplayName("Job Type")]

        public string JobType { get; set; }
        [Required(ErrorMessage = "Please enter additional requirements")]
        public string AdditionalRequirements { get; set; }
        [Required(ErrorMessage = "Please enter gender")]
        public string Gender { get; set; }

        public string PostDate { get; set; }
    }
}