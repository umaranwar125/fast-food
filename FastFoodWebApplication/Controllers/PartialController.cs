using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFoodWebApplication.ViewModel;
using FastFoodWebApplication.Models;

namespace FastFoodWebApplication.Controllers
{
    public class PartialController : Controller
    {
        CategoryRepository ob = new CategoryRepository();
        // GET: Shared

        public ActionResult MenuPartial()
        {
            List<CategoryModel> list = ob.displayCategories();
            return PartialView(list);
        }
    }
}