using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Ninject;
using NinjectTest.Models;


namespace NinjectTest.Infrastructure
{
    public class NinjectDependencyResolver : NinjectDependencyScope, System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(this.kernel.BeginBlock());
        }
    }

}