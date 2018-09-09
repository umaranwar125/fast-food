using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FastFoodWebApplication.Areas.AdminPanel.Controllers
{
    public class DashboardController : Controller
    {
        // GET: AdminPanel/Dashboard
        public ActionResult Statistics()
        {
            return View();
        }
    }
}