using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFoodWebApplication.ViewModel;
using FastFoodWebApplication.Models;

namespace FastFoodWebApplication.Controllers
{
    public class HomeController : Controller
    {
        ContactRepository ob = new ContactRepository();
        CategoryRepository ob1 = new CategoryRepository();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                if (ob.insertContact(contact))
                {
                    TempData["InsertData"] = "<script>alert('Message has been successfully send').</script>";
                    TempData.Keep();
                }
            }
            return View();
        }
    }
}