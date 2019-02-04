using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneNineProject.Models;

namespace OneNineProject.Controllers
{
    public class DeleteController : Controller
    {
        private readonly IRepository rep;

        public DeleteController(IRepository r)
        {
            rep = r;
        }

        public ActionResult DeleteDoc(int Id)
        {
            rep.DeleteDoc(Id);
            rep.Save();
            return RedirectToRoute("MainPage");
        }
    }
}