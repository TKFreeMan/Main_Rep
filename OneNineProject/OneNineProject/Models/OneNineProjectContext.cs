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

        public DbSet<DocViewModel> Docs { get; set; }
    }

    public class OneNineRepository : IRepository
    {
        private OneNineProjectContext db = new OneNineProjectContext();

        public void AddDoc(DocViewModel newDoc)
        {
            db.Docs.Add(newDoc);
        }

        public DocViewModel FindDoc(int Id)
        {
            return db.Docs.Find(Id);
        }

        public void DeleteDoc(int Id)
        {
            DocViewModel findedDoc = db.Docs.Find(Id);
            if(Id != null)
            {
                db.Docs.Remove(findedDoc);
                db.SaveChanges();
            }
        }

        public void UpdateDoc(DocViewModel updDoc)
        {
            db.Entry(updDoc).State = EntityState.Modified;
            Save();
        }

        public List<DocViewModel> DocsToList()
        {
            List<DocViewModel> docs = new List<DocViewModel>();
            foreach (var doc in db.Docs)
            {
                docs.Add(doc);
            }
            return docs;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
