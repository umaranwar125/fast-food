using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FastFoodWebApplication.Models.DBContext;
using FastFoodWebApplication.Models;

namespace FastFoodWebApplication.ViewModel
{
    public class ProductRepository
    {
        DBContextFile db = new DBContextFile();
        public List<ProductModel> displayProductList()
        {
            return db.Products.SqlQuery("SELECT * FROM ProductModels ORDER BY ProductID DESC").ToList();
        }

        public bool insertProduct(ProductModel model, string Category)
        {
            try {
                model.CategoryRefID = db.Categories.Where(m => m.CategoryName == Category).Select(m => m.CategoryID).FirstOrDefault();
                db.Products.Add(model);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool deleteProduct(int DeleteID)
        {
            try {
                ProductModel produt = db.Products.Find(DeleteID);
                db.Products.Remove(produt);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public ProductModel selectProductForUpdation(int UpdateID)
        {
            return db.Products.Find(UpdateID);
        }

        public bool updateProduct(ProductModel product, string Category)
        {
            try {
                product.CategoryRefID = db.Categories.Where(m => m.CategoryName == Category).Select(m => m.CategoryID).FirstOrDefault();
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
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