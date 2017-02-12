using PSTodos.Application.AutoMapper;
using PSTodos.Infrastructure.IoC;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace PSTodos.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectHttpContainer.RegisterModules(NinjectHttpModules.Modules);

            AutoMapperConfig.RegisterMappings();
        }
    }
}
