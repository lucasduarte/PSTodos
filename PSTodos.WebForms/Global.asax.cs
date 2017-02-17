using PSTodos.RESTServices;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Diagnostics;
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.UI;

namespace PSTodos.WebForms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Bootstrap();
        }

        private static Container container;

        public static void InitializeHandler(IHttpHandler handler)
        {
            container.GetRegistration(handler.GetType(), true).Registration
                .InitializeInstance(handler);
        }

        private static void Bootstrap()
        {
            // 1. Create a new Simple Injector container.
            var container = new Container();

            // Register a custom PropertySelectionBehavior to enable property injection.
            container.Options.PropertySelectionBehavior =
                new ImportAttributePropertySelectionBehavior();

            // 2. Configure the container (register)
            container.Register<IUsuarioRESTService, UsuarioRESTService>();
            container.Register<IPerfilRESTService, PerfilRESTService>();
            container.Register<IUsuarioPerfilRESTService, UsuarioPerfilRESTService>();
            // Register your Page classes to allow them to be verified and diagnosed.
            RegisterWebPages(container);

            // 3. Store the container for use by Page classes.
            Global.container = container;

            // 3. Verify the container's configuration.
            container.Verify();
        }

        private static void RegisterWebPages(Container container)
        {
            var pageTypes =
                from assembly in BuildManager.GetReferencedAssemblies().Cast<Assembly>()
                where !assembly.IsDynamic
                where !assembly.GlobalAssemblyCache
                from type in assembly.GetExportedTypes()
                where type.IsSubclassOf(typeof(Page))
                where !type.IsAbstract && !type.IsGenericType
                select type;

            foreach (Type type in pageTypes)
            {
                var registration = Lifestyle.Transient.CreateRegistration(type, container);
                registration.SuppressDiagnosticWarning(
                    DiagnosticType.DisposableTransientComponent,
                    "ASP.NET creates and disposes page classes for us.");
                container.AddRegistration(type, registration);
            }
        }

        class ImportAttributePropertySelectionBehavior : IPropertySelectionBehavior
        {
            public bool SelectProperty(Type serviceType, PropertyInfo propertyInfo)
            {
                // Makes use of the System.ComponentModel.Composition assembly
                return typeof(Page).IsAssignableFrom(serviceType) &&
                    propertyInfo.GetCustomAttributes<ImportAttribute>().Any();
            }
        }
    }
}