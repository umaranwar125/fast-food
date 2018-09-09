using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FastFoodWebApplication.Areas.AdminPanel.Controllers
{
    public class ProfileController : Controller
    {
        // GET: AdminPanel/Profile
        public ActionResult User()
        {
            return View();
        }
    }
}