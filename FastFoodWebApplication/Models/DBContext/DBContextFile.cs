using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using FastFoodWebApplication.Models;
using System.Web;

namespace FastFoodWebApplication.Models.DBContext
{
    public class DBContextFile : DbContext
    {
        public DbSet<RegisterModel> Registers { get; set; }
        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegisterModel>().MapToStoredProcedures();
            base.OnModelCreating(modelBuilder);
        }
    }
}