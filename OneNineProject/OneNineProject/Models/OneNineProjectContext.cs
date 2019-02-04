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

       
      

       

    }
}
