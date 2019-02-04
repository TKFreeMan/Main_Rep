using System;
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
            List<DocViewModel> fullDocCollection = new List<DocViewModel>();
            var docs = rep.DocsToList();
            foreach (var doc in docs)
            {
                DocViewModel tempDoc = new DocViewModel();
                tempDoc.DocId = doc.DocId;
                tempDoc.Seсrecy = doc.Seсrecy;
                tempDoc.DocDate = doc.DocDate;
                tempDoc.ReceiveDate = doc.ReceiveDate;
                tempDoc.Unit = doc.Unit;
                foreach (Person pers in doc.Persons)
                {
                    tempDoc.Persons += pers.Name + "\r\n";
                }
                tempDoc.WorkTypes = doc.WorkTypes;
                foreach (Executor executor in doc.Executors)
                {
                    tempDoc.Executors += executor.Name + "\r\n";
                }
                tempDoc.CheckMarks = doc.CheckMarks;
                tempDoc.Notes = doc.Notes;
                tempDoc.Status = doc.Status;
                fullDocCollection.Add(tempDoc);
            }
            return View(fullDocCollection);
        }
    }
}