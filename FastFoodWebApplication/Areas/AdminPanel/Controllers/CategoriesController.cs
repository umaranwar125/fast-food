using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFoodWebApplication.ViewModel;
using FastFoodWebApplication.Models;

namespace FastFoodWebApplication.Areas.AdminPanel.Controllers
{
    public class CategoriesController : Controller
    {
        CategoryRepository ob = new CategoryRepository();

        // GET: AdminPanel/Categories
        public ActionResult Menu()
        {
            if (Request.QueryString["UpdateID"] != null)
            {
                ViewBag.Datas = "showContent();";
                CategoryModel category = ob.getDetails(Convert.ToInt32(Request.QueryString["UpdateID"]));
                listDisplay();
                return View(category);
            }
            else
            {
                listDisplay();
                return View();
            }
        }

        [HttpPost]
        public ActionResult Menu(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                if (Request.QueryString["UpdateID"] != null)
                {
                    if (ob.updateCategory(category))
                    {
                        TempData["UpdateSuccess"] = "Category has been updated successfully.";
                        TempData.Keep();
                    }
                }
                else
                {
                    if (ob.insertCategory(category))
                    {
                        TempData["InsertSuccess"] = "Category has been added successfully.";
                        TempData.Keep();
                    }
                }
            }
            return RedirectToAction("Menu", "Categories");
        }


        // Diplay Categories 
        private void listDisplay()
        {
            List<CategoryModel> list = ob.displayCategories();
            if (list.Count == 0)
                ViewBag.TotalList = list.Count;
            ViewBag.List = list;
        }
    }
}