﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EatOutByBI.Domain.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ALaCarte()
        {
            return View();
        }

        public ActionResult Drinks()
        {
            return View();
        }

        public ActionResult Desserts()
        {
            return View();
        }
        
    }
}