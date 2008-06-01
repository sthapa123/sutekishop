﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Suteki.Shop.ViewData;

namespace Suteki.Shop.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            return View("Index", ShopView.Data);
        }

        public ActionResult Error()
        {
            throw new ApplicationException("This error was thrown!");
        }
    }
}