using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using FastFoodWebApplication.ViewModel;
using FastFoodWebApplication.Models;

namespace FastFoodWebApplication.Areas.AdminPanel.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository ob = new ProductRepository();
        CategoryRepository ob1 = new CategoryRepository();
        List<ProductModel> list;
        // GET: AdminPanel/Product
        public ActionResult Data()
        {
            if (Request.QueryString["UpdateID"] != null)
            {
                ViewBag.Datas = "showContent();";
                ProductModel product = ob.selectProductForUpdation(Convert.ToInt32(Request.QueryString["UpdateID"]));
                displayList();
                catList();
                return View(product);
            }
            else
            {
                displayList();
                catList();
                return View();
            }
        }

        [HttpPost]
        public ActionResult Data(HttpPostedFileBase myFile, ProductModel model, string Category)
        {
            if (Request.QueryString["UpdateID"] != null)
            {
                model.Image = myFile.FileName.ToString();
                if (ob.updateProduct(model, Category))
                {
                    storeImage(myFile);
                    displayAllFtn();
                    TempData["UpdateSuccess"] = "Product has benn updated.";
                    return RedirectToAction("Data", "Product");
                }
                else
                {
                    displayAllFtn();
                    ViewBag.CategorySelect = "Please Select Category";
                }
            }
            else
            {
                model.Image = myFile.FileName.ToString();
                if (ob.insertProduct(model, Category))
                {
                    storeImage(myFile);
                    displayAllFtn();
                    TempData["InsertSuccess"] = "Product has been added.";
                }
                else
                {
                    displayAllFtn();
                    ViewBag.CategorySelect = "Please Select Category";
                }
            }
            return View();
        }

        // Display List
        private void displayList()
        {
            list = ob.displayProductList();
            if (list.Count == 0)
                ViewBag.TotalProductList = list.Count;
            ViewBag.ProductList = list;
        }

        // Store Image
        private void storeImage(HttpPostedFileBase myFile)
        {

            string FileName = Path.GetFileName(myFile.FileName);
            string FolderName = Path.Combine(Server.MapPath("~/Images"), FileName);
            myFile.SaveAs(FolderName);
        }

        // Category List
        private List<SelectListItem> catList()
        {
            List<SelectListItem> item = new List<SelectListItem>();
            List<CategoryModel> catItems = ob1.displayCategories();
            if(catItems.Count != 0)
                item.Add(new SelectListItem { Text = "Select Category", Disabled = true, Selected = true, Value = "!" });
            if (catItems.Count != 0)
            {
                foreach (var data in catItems)
                {
                    item.Add(new SelectListItem { Text = data.CategoryName, Value = data.CategoryName });
                }
            }
            else
                item.Add(new SelectListItem { Text = "No categories are available", Disabled = true, Selected = true});
            ViewBag.Categories = item;
            return item;
        }

        // Delete Product
        public ActionResult Delete(int DeleteID)
        {
            if (ob.deleteProduct(DeleteID))
            {
                TempData["DeleteSuccess"] = "Product has been deleted";
                TempData.Keep();
            }
            return RedirectToAction("Data", "Product");
        }

        // Combining all functions
        private void displayAllFtn()
        {
            displayList();
            catList();
        }
    }
}