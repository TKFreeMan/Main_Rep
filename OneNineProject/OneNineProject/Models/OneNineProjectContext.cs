using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OneNineProject.Models
{
    public class OneNineProjectContext : DbContext
    {
        public OneNineProjectContext() : base("DefaultConnection")
        {

        }

        public DbSet<Doc> Docs { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Executor> Executors { get; set; }
    }

    public class OneNineRepository : IRepository
    {
        private OneNineProjectContext db = new OneNineProjectContext();

        public void Add(Doc doc)
        {
            db.Docs.Add(doc);
        }

        public void Add(Person person)
        {
            db.Persons.Add(person);
        }

        public Doc FindFullDoc(int? id)
        {
            try
            {
                Doc findedDoc = db.Docs
                    .Include(p => p.Persons)
                    .Include(e => e.Executors)
                    .SingleOrDefault(r => r.DocId == id);
                return findedDoc;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Person FindPerson(int id)
        {
            Person findedPerson = db.Persons.Find(id);

            if (findedPerson == null)
            {
                return null;
            }
            else
            {
                return findedPerson;
            }
        }

        public Executor FindExecutor(int id)
        {
            Executor findedEx = db.Executors.Find(id);
            if (findedEx == null)
            {
                return null;
            }
            else
            {
                return findedEx;
            }
        }

        public void Add(Executor executor)
        {
            db.Executors.Add(executor);
        }

        public List<Doc> DocsToList()
        {
            var IncludedDoc = db.Docs.Include(p => p.Persons).Include(e => e.Executors);
            return IncludedDoc.ToList();
        }

        public List<Person> PersonsToList()
        {
            return db.Persons.ToList();
        }

        public List<Executor> ExecutorsToList()
        {
            return db.Executors.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
