using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OneNineProject.Models;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace OneNineProject.Controllers
{
    public class EditController: Controller
    {
        private readonly IRepository rep;

        public EditController(IRepository r)
        {
            rep = r;
        }

        public ActionResult EditDoc(int Id)
        {
            DocViewModel findedDoc = rep.FindDoc(Id);
            return View("EditView", findedDoc);
        }

        [HttpPost]
        public ActionResult EditDoc(DocViewModel model)
        {
            rep.UpdateDoc(model);
            return View("EditResult");
        }
    }
}