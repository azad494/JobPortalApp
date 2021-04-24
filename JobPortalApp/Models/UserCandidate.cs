using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortalApp.Models
{
    public class UserCandidate
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
    }
}