using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FastFoodWebApplication.Models.DBContext;
using FastFoodWebApplication.Models;
using System.Web.Security;

namespace FastFoodWebApplication.ViewModel
{
    public class RegisterRepository
    {
        DBContextFile dbCxt = new DBContextFile();
        
        // Registration
        public bool insertData(RegisterModel register)
        {
            string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(register.Password,"MD5");
            register.Password = pwd;
            dbCxt.Registers.Add(register);
            dbCxt.SaveChanges();
            return true;
        }


        // Email Existance Checking
        public bool emailCheck(RegisterModel register)
        {
            var queryResult = dbCxt.Registers.Where(m => m.EmailAddress == register.EmailAddress).FirstOrDefault();
            if (queryResult != null)
                return false;
            else
                return true;
        }


        // Selection
        public bool selectData(RegisterModel register)
        {
            string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(register.Password, "MD5");
            var queryResult = dbCxt.Registers.Where(m => m.EmailAddress == register.EmailAddress && m.Password == pwd).FirstOrDefault();
            if (queryResult != null)
                return true;
            else
                return false;
        }

        // Select All Data for Admin Panel
        public List<RegisterModel> selectDataForAdminPanel()
        {
            return dbCxt.Registers.SqlQuery("SELECT * FROM RegisterModels ORDER BY RegisterID Desc").ToList();
        }


        // Delete Registration Data
        public bool deleteData(int DeleteID)
        {
            try
            {
                RegisterModel myOb = new RegisterModel();
                myOb =  dbCxt.Registers.Find(DeleteID);
                dbCxt.Registers.Remove(myOb);
                dbCxt.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}