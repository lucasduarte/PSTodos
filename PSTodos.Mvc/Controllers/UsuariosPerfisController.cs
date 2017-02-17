using PSTodos.Mvc.Notifications;
using PSTodos.RESTServices;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PSTodos.Mvc.Controllers
{
    public class UsuariosPerfisController : Controller
    {
        private readonly IUsuarioPerfilRESTService _service;

        public UsuariosPerfisController(IUsuarioPerfilRESTService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult AdicionarUsuarioPerfil(int usuarioId, int perfilId)
        {
            var vm = _service.AdicionarPerfil(usuarioId, perfilId);

            if (vm.Success)
            {
                this.AddToastMessage("", "Perfil atribuído ao Usuário", ToastType.Success);
            }
            else
            {
                this.AddToastMessage("", "Falha ao atribuir Perfil ao Usuário", ToastType.Error);
            }
            return RedirectToAction("Edit", "Usuarios", new { Id = usuarioId });
        }


        [HttpPost]
        public ActionResult RemoverUsuarioPerfil(int usuarioId, int perfilId)
        {
            var vm = _service.RemoverPerfil(usuarioId, perfilId);

            if (vm.Success)
            {
                this.AddToastMessage("", "Perfil removido do Usuário", ToastType.Success);
            }
            else
            {
                this.AddToastMessage("", "Falha ao remover Perfil do Usuário", ToastType.Error);
            }

            return RedirectToAction("Edit", "Usuarios", new { Id = usuarioId });
        }

    }
}