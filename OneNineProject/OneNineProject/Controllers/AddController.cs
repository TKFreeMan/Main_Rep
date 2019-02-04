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
        public ActionResult AddDoc(DocViewModel model)
        {
            //Creating new doc Entity
            Doc newDoc = new Doc
            {
                DocId = model.DocId,
                Seсrecy = model.Seсrecy,
                DocDate = model.DocDate,
                ReceiveDate = model.ReceiveDate,
                Unit = model.Unit,
            };

            //Get persons from textarea in AddView
            string[] personsColl = model.Persons.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            ICollection<Person> newPersons = new List<Person>();
            foreach (var item in personsColl)
            {
                Person newPerson = new Person
                {
                    Name = item,
                    DocId = model.DocId,
                    Doc = newDoc
                };
                newPersons.Add(newPerson);
                rep.Add(newPerson);
            }
            //Adding collection of persons to new Doc entity
            newDoc.Persons = newPersons;

            //Get worktype from textarea in AddView
            newDoc.WorkTypes = model.WorkTypes;

            //Get Executors from textarea in AddView
            string[] executorColl = model.Executors.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            ICollection<Executor> newExecutors = new List<Executor>();
            foreach(var item in executorColl)
            {
                Executor newExecutor = new Executor
                {
                    Name = item,
                    DocId = model.DocId,
                    Doc = newDoc
                };
                newExecutors.Add(newExecutor);
                rep.Add(newExecutor);
            }

            //Adding collection of executors to new Doc entity
            newDoc.Executors = newExecutors;
            newDoc.CheckMarks = model.CheckMarks;
            newDoc.Notes = model.Notes;
            newDoc.Status = model.Status;

            //Adding new doc to doc table
            rep.Add(newDoc);
            rep.Save();
            return View("AddResult");
        }
    }
}