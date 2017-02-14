using PSTodos.Mvc.RESTServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PSTodos.Mvc.Controllers
{
    public class PerfisController : Controller
    {
        private PerfilRESTService service = new PerfilRESTService();
        // GET: Perfis
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult ListarPerfis()
        {
            var vm =  Task.Run(service.ObterPerfilsAsync).Result;
            
            return PartialView("_ListarPerfisPartial", vm.Result);
        }
    }
}