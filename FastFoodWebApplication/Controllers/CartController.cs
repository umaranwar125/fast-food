﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FastFoodWebApplication.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Shopping()
        {
            return View();
        }
    }
}