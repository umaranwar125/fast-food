using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFoodWebApplication.Models;
using FastFoodWebApplication.ViewModel;

namespace FastFoodWebApplication.Areas.AdminPanel.Controllers
{
    public class ContactController : Controller
    {
        ContactRepository ob = new ContactRepository();

        // GET: AdminPanel/Contact
        public ActionResult Data()
        {
            List<ContactModel> list = ob.selectAllContacts();
            if (list.Count == 0)
                ViewBag.TotalList = list.Count;
            ViewBag.List = list;
            return View();
        }


        // Delete
        public ActionResult Delete(int DeleteID)
        {
            if (ob.deleteContactData(DeleteID))
            {
                TempData["DeleteSuccess"] = "Data has been deleted successfully";
                TempData.Keep();
            }
            return RedirectToAction("Data", "Contact");
        }

    }
}