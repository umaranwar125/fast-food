using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFoodWebApplication.Models;
using FastFoodWebApplication.ViewModel;

namespace FastFoodWebApplication.Areas.AdminPanel.Controllers
{
    public class RegistrationController : Controller
    {
        RegisterRepository ob = new RegisterRepository();
        // GET: AdminPanel/Registration
        [HttpGet]
        public ActionResult Users()
        {
            List<RegisterModel> list = ob.selectDataForAdminPanel();
            if (list.Count == 0)
                ViewBag.TotalList = list.Count;
            ViewBag.List = list;

            return View();
        }

        public ActionResult Delete(int Deleteid)
        {
            if (ob.deleteData(Deleteid))
            {
                TempData["DeleteSuccess"] = "Record has been deleted successfully";
                TempData.Keep();
            }
            return RedirectToAction("Users", "Registration");
        }
    }
}