using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FastFoodWebApplication.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string CategoryName { get; set; }

        public ICollection<ProductModel> Products { get; set; }
    }
}