using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OneNineProject.Models;
using Ninject.Modules;

namespace OneNineProject.Unit
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<OneNineRepository>();
        }
    }
}