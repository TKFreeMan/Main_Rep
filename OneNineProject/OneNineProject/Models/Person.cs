using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneNineProject.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //Id of document
        public int DocId { get; set; }

        //Navigation property
        public Doc Doc { get; set; }
    }
}