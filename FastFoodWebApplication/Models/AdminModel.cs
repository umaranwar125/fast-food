using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FastFoodWebApplication.Models
{
    public class AdminModel
    {
        public int AdminModelID { get; set; }

        [Required(ErrorMessage = "Username is requred")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password 1 is requred")]
        public string Password1 { get; set; }

        [Required(ErrorMessage = "Password 2 is requred")]
        public string Password2 { get; set; }
    }
}