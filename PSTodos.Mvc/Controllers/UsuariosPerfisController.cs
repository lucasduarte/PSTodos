using PSTodos.Mvc.Notifications;
using PSTodos.Mvc.Notifications;
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

            if(vm.Success)
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
        public async Task<ActionResult> RemoverUsuarioPerfil(int usuarioId, int perfilId)
        {
            var vm = await service.RemoverUsuarioPerfilAsync(usuarioId, perfilId);

            if (vm.Success)
            {
                this.AddToastMessage("", "Perfil removido do Usuário", ToastType.Success);
            }
            else
            {
                this.AddToastMessage("", "Falha ao remover Perfil do Usuário", ToastType.Error);
            }

            return RedirectToAction("", "Usuarios", new { Id = usuarioId });
        }

    }
}