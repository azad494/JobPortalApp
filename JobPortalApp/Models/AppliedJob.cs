using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortalApp.Models
{
    public class AppliedJob
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter company")]
        public string Company { get; set; }
        [Required(ErrorMessage = "Please enter job title")]
        public string JobTitle { get; set; }
        [Required(ErrorMessage = "Please enter applicant's name")]
        [Display(Name = "Name")]
        public string ApplicantName { get; set; }
        [Required(ErrorMessage = "Please enter birthdate")]
        [Display(Name = "Birth Date")]
        public string ApplicantBd { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter address")]
        public string ApplicantAddress { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        [Display(Name = "Email")]
        public string ApplicantEmail { get; set; }
        [Required(ErrorMessage = "Please enter cv")]
        [Display(Name = "CV")]
        public string ApplicantCv { get; set; }
    }
}