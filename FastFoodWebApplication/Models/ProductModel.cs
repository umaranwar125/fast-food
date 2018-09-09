using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FastFoodWebApplication.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductID { get; set; }

        public int CategoryRefID { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Image { get; set; }

        [ForeignKey("CategoryRefID")]
        public CategoryModel Category { get; set; }
    }
}