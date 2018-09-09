using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFoodWebApplication.Models;
using FastFoodWebApplication.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace FastFoodWebApplication.Controllers
{
    public class AccountController : Controller
    {
        RegisterRepository ob = new RegisterRepository();

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }


        // Register
        [HttpPost]
        public ActionResult Register(RegisterModel register, string Password2)
        {
            if (Password2 == "")
                ModelState.AddModelError("pwd", "Password is required");
            else if (ModelState.IsValid)
            {
                if (isValid(register.EmailAddress))
                {
                    if (register.Password == Password2)
                    {
                        if (ob.emailCheck(register))
                        {
                            if (ob.insertData(register))
                            {
                                TempData["RegisterSuccessfull"] = "Registration has been successfuly completed";
                                return RedirectToAction("Login", "Account");
                            }
                        }
                        else
                            ViewBag.EmailExistError = "Sorry, Email is already exist.";
                    }
                    else
                        ViewBag.Password = "Password is not match";
                }
                else
                    ViewBag.EmailError = "Email address is not valid";
            }
            return View();
        }



        // Login
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(RegisterModel register)
        {
            if (ob.selectData(register))
            {
                Session["UserEmail"] = register.EmailAddress;
                return RedirectToAction("Index", "Home");
            }
            else
                ViewBag.ErrorLogin = "Username or password is incorrect.";
            return View();
        }

        // Checking Email Validation
        public bool isValid(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
