using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FastFoodWebApplication.Models.DBContext;
using FastFoodWebApplication.Models;

namespace FastFoodWebApplication.ViewModel
{
    public class CategoryRepository
    {
        DBContextFile db = new DBContextFile();

        public bool insertCategory(CategoryModel category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return true;
        }

        // Display all categories
        public List<CategoryModel> displayCategories()
        {
            return db.Categories.SqlQuery("SELECT * FROM CategoryModels ORDER BY CategoryID DESC").ToList();
        }

        // Fetching Category Details
        public CategoryModel getDetails(int UpdateID)
        {
            return db.Categories.Find(UpdateID);
        }

        // Updating Category 
        public bool updateCategory(CategoryModel category)
        {
            try {
                db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}