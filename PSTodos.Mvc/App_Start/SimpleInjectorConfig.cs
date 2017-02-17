using PSTodos.RESTServices;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;

namespace PSTodos.Mvc
{
    public static class SimpleInjectorConfig
    {
        public static void Config()
        {
            // 1. Create a new Simple Injector container
            var container = new Container();

            // 2. Configure the container (register)
            container.Register<IPerfilRESTService, PerfilRESTService>();
            container.Register<IUsuarioPerfilRESTService, UsuarioPerfilRESTService>();
            container.Register<IUsuarioRESTService, UsuarioRESTService>();


            // 4. Register the container as MVC IDependencyResolver.
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}