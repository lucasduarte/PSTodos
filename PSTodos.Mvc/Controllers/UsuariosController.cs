using PSTodos.Mvc.RESTServices;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PSTodos.Mvc.Controllers
{
    public class UsuariosController : Controller
    {
        private UsuarioRESTService service = new UsuarioRESTService();

        public async Task<ActionResult> Index()
        {
            var vm = await service.ObterUsuariosAsync();

            return View(vm.Result);
        }
    }
}