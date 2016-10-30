using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using NinjectTest.Models;

namespace NinjectTest.Infrastructure
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
           //  Bind<IBestStudent>().To<BestMathStudent>().InSingletonScope();
             Bind<IBestStudent>().To<BestChemistryStudent>().InSingletonScope();
            // Bind<IBestStudent>().To<BestAverageStudent>().InSingletonScope();
        }
    }
}