using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FastFoodWebApplication.Models.DBContext;
using FastFoodWebApplication.Models;

namespace FastFoodWebApplication.ViewModel
{
    public class ContactRepository
    {
        DBContextFile db = new DBContextFile();

        // Insert Contact Data
        public bool insertContact(ContactModel model)
        {
            db.Contacts.Add(model);
            db.SaveChanges();
            return true;
        }

        // Select Contact Data
        public List<ContactModel> selectAllContacts()
        {
            return db.Contacts.SqlQuery("Select * FROM ContactModels Order By ContactID DESC").ToList();
        }

        public bool deleteContactData(int DeleteID)
        {
            try
            {
                ContactModel contact = db.Contacts.Find(DeleteID);
                db.Contacts.Remove(contact);
                db.SaveChanges();
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