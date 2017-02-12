using Ninject.Modules;
using System.Web.Http;
using System.Reflection;
using Ninject;

namespace PSTodos.Infrastructure.IoC
{
    public class NinjectHttpContainer
    {
        private static NinjectHttpResolver _resolver;

        //Register Ninject Modules
        public static void RegisterModules(NinjectModule[] modules)
        {
            _resolver = new NinjectHttpResolver(modules);
            GlobalConfiguration.Configuration.DependencyResolver = _resolver;

            
        }

        public static void RegisterAssembly()
        {
            _resolver = new NinjectHttpResolver(Assembly.GetExecutingAssembly());
            //This is where the actual hookup to the Web API Pipeline is done.
            GlobalConfiguration.Configuration.DependencyResolver = _resolver;
        }

        //Manually Resolve Dependencies
        public static T Resolve<T>()
        {
            return _resolver.Kernel.Get<T>();
        }
    }
}