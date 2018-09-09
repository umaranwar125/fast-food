using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFoodWebApplication.ViewModel;
using FastFoodWebApplication.Models;

namespace FastFoodWebApplication.Controllers
{
    public class ProductController : Controller
    {
        CategoryRepository ob = new CategoryRepository();

        // GET: Product
        public ActionResult Categories()
        {
            List<CategoryModel> list = ob.displayCategories();
            if (list.Count == 0)
                ViewBag.TotalCategoryList = list.Count;
            ViewBag.CategoryList = list;
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }
    }
}