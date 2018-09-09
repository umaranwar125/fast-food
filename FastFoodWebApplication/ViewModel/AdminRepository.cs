using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using FastFoodWebApplication.Models;
using FastFoodWebApplication.Models.DBContext;

namespace FastFoodWebApplication.ViewModel
{
    public class AdminRepository
    {
        DBContextFile db = new DBContextFile();

        // Select datafor Admin Login.
        public bool selectAdminLogin(AdminModel admin)
        {
            string pwd1 = FormsAuthentication.HashPasswordForStoringInConfigFile(admin.Password1,"MD5");
            string pwd2 = FormsAuthentication.HashPasswordForStoringInConfigFile(admin.Password2,"MD5");
            var queryResult = db.Admins.Where(m => m.Username == admin.Username && m.Password1 == pwd1 && m.Password2 == pwd2).FirstOrDefault();
            if (queryResult != null)
                return true;
            else
                return false;
        }
    }
}