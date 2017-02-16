using System.Web.Http;
using WebActivatorEx;
using PSTodos.Api;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace PSTodos.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration 
                .EnableSwagger(c =>
                    {
                        
                        c.SingleApiVersion("v1", "PSTodos.Api");
                        //c.IncludeXmlComments(GetXmlCommentsPath());
                    })
                .EnableSwaggerUi(c =>
                {
                        
                });

        }

        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\PSTodos.Api.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
