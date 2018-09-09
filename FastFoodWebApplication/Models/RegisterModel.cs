using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FastFoodWebApplication.Models
{
    public class RegisterModel
    {
        [Key]
        public int RegisterID { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}