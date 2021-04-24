using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortalApp.Models
{
    public class UserEmployer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter birthdate")]
        public string Birthdate { get; set; }
        [Required(ErrorMessage = "Please enter gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }

        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyTradeLicense { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyCategory { get; set; }

    }
}