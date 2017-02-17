using PSTodos.Application.AutoMapper;
using PSTodos.Infrastructure.IoC;
using System.Web.Http;

namespace PSTodos.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            NinjectHttpContainer.RegisterModules(NinjectHttpModules.Modules);

            AutoMapperConfig.RegisterMappings();        
        }
    }
}
