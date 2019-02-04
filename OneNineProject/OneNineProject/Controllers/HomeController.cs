﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneNineProject.Models;

namespace OneNineProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly IRepository rep;

        public HomeController(IRepository r)
        {
            rep = r;
        }
        public ActionResult MainPage()
        {
            return View(rep.DocsToList());
        }
    }
}