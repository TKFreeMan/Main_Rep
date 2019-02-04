using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneNineProject.Models;
using Ninject;

namespace OneNineProject.Controllers
{
    public class AddController : Controller
    {
        private readonly IRepository rep;
        public AddController(IRepository r)
        {
            rep = r;
        }
        public ActionResult AddView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDoc(DocViewModel doc)
        {
            rep.AddDoc(doc);
            rep.Save();
            return View("AddResult");
        }
    }
}