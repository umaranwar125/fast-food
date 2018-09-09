using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FastFoodWebApplication.Models
{
    public class ContactModel
    {
        [Key]
        public int ContactID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email is not in valid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }


    }
}