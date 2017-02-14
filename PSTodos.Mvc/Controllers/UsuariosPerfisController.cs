using PSTodos.Mvc.RESTServices;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PSTodos.Mvc.Controllers
{
    public class UsuariosPerfisController : Controller
    {
        private UsuarioPerfilRESTService service = new UsuarioPerfilRESTService();

        [HttpPost]
        public async Task<ActionResult> AdicionarUsuarioPerfil(int usuarioId, int perfilId)
        {
            var vm = await service.CadastrarUsuarioPerfilAsync(usuarioId, perfilId);

            return RedirectToAction("Edit", "Usuarios", new { Id = usuarioId });
        }


        [HttpPost]
        public async Task<ActionResult> RemoverUsuarioPerfil(int usuarioId, int perfilId)
        {
            var vm = await service.RemoverUsuarioPerfilAsync(usuarioId, perfilId);

            return RedirectToAction("Edit", "Usuarios", new { Id = usuarioId });
        }

    }
}