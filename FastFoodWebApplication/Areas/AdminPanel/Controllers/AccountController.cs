using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFoodWebApplication.Models;
using FastFoodWebApplication.Models.DBContext;
using FastFoodWebApplication.ViewModel;

namespace FastFoodWebApplication.Areas.AdminPanel.Controllers
{
    public class AccountController : Controller
    {
        AdminRepository ob = new AdminRepository();

        // GET: AdminPanel/Account
        public ActionResult Login()
        {
        //    admin.Username = "Admin";
        //    admin.Password1 = "E3AFED0047B08059D0FADA10F400C1E5";
        //    admin.Password2 = "E3AFED0047B08059D0FADA10F400C1E5";
        //    DBContextFile ob1 = new DBContextFile();
        //    ob1.Admins.Add(admin);
        //    ob1.SaveChanges();
            return View();
        }


        [HttpPost]
        public ActionResult Login(AdminModel admin)
        {
            if (ModelState.IsValid)
            {
                if (ob.selectAdminLogin(admin))
                    return RedirectToAction("Statistics", "Dashboard");
                else
                    ViewBag.ErrorLogin = "Username or password is incorrect";
            }
            return View();
        }
    }
}