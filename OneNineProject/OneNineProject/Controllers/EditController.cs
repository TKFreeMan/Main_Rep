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

        public ActionResult EditDoc(int DocId)
        {

            Doc findedDoc = rep.FindFullDoc(DocId);

            DocViewModel tempDoc = new DocViewModel();
            tempDoc.DocId = findedDoc.DocId;
            tempDoc.Seсrecy = findedDoc.Seсrecy;
            tempDoc.DocDate = findedDoc.DocDate;
            tempDoc.ReceiveDate = findedDoc.ReceiveDate;
            tempDoc.Unit = findedDoc.Unit;
            foreach (var person in findedDoc.Persons)
            {
                tempDoc.Persons += person.Name;
            }

            tempDoc.WorkTypes = findedDoc.WorkTypes;

            foreach (var executor in findedDoc.Executors)
            {
                tempDoc.Executors += executor.Name;
            }

            tempDoc.CheckMarks = findedDoc.CheckMarks;
            tempDoc.Notes = findedDoc.Notes;
            tempDoc.Status = findedDoc.Status;
            return View("EditView", tempDoc);
        }

        [HttpPost]
        public ActionResult EditDoc(DocViewModel model)
        {
            Doc tempDoc = new Doc();
            tempDoc.DocId = model.DocId;
            tempDoc.Seсrecy = model.Seсrecy;
            tempDoc.DocDate = model.DocDate;
            tempDoc.ReceiveDate = model.ReceiveDate;
            tempDoc.Unit = model.Unit;
            MatchCollection matches = Regex.Matches(model.Persons, @"[a-zа-яёэіїє]+\s[a-zа-яёэіїє].[a-zа-яёэіїє].|[a-zа-яёэіїє]+[a-zа-яёэіїє].[a-zа-яёэіїє].", RegexOptions.IgnoreCase);
            foreach (Match match in matches)
            {
                tempDoc.Persons.
            }

            return View("AddResult");

        }
    }
}