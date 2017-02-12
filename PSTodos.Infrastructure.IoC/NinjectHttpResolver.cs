using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http.Dependencies;

namespace PSTodos.Infrastructure.IoC
{
    public class NinjectHttpResolver : IDependencyResolver, IDependencyScope
    {
        public IKernel Kernel { get; private set; }
        public NinjectHttpResolver(params NinjectModule[] modules)
        {
            Kernel = new StandardKernel(modules);
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(Kernel));
        }

        public NinjectHttpResolver(Assembly assembly)
        {
            Kernel = new StandardKernel();
            Kernel.Load(assembly);
        }

        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }

        public void Dispose()
        {
            //Do Nothing
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }
    }
}
