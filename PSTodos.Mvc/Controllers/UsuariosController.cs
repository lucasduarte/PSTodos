using PSTodos.Mvc.Notifications;
using PSTodos.RESTServices;
using PSTodos.RESTServices.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PSTodos.Mvc.Controllers
{
    public class UsuariosController : Controller
    {
        private UsuarioRESTService service = new UsuarioRESTService();

        public ActionResult Index()
        {
            var vm = service.ObterUsuarios();

            return View(vm.Result);
        }

        public ActionResult Create()
        {
            var vm = new UsuarioViewModel();
            vm.DtInclusao = DateTime.Now;

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(UsuarioViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                this.AddToastMessage("", "Falha ao cadastrar Usuário", ToastType.Error);
                return View("Create", vm);
            }

            var result = service.CadastrarUsuario(vm);

            if(result.Success)
            {
                this.AddToastMessage("", "Usuário cadastrado com sucesso", ToastType.Success);
                return RedirectToAction("Index");
            }
            else
            {
                this.AddToastMessage("", "Falha ao cadastrar Usuário", ToastType.Error);
                return View("Create", vm);
            }
        } 

        public ActionResult Edit(int id)
        {
            var vm = service.ObterUsuario(id);

            return View("Edit", vm.Result);
        }

        [HttpPut]
        public ActionResult Edit(int id, UsuarioViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                this.AddToastMessage("", "Falha ao alterar Usuário", ToastType.Error);
                return View("Edit", vm);
            }

            var result = service.EditarUsuario(id, vm);

            if(result.Success)
            {
                this.AddToastMessage("", "Usuário alterado com sucesso", ToastType.Success);
                return RedirectToAction("Index");
            }
            else
            {
                this.AddToastMessage("Erro", "Falha ao alterar Usuário", ToastType.Error);
                return View("Edit", vm);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var result = service.RemoverUsuario(id);

            this.AddToastMessage("", "Usuário removido com sucesso", ToastType.Success);
            return RedirectToAction("Index");
        }
    }

}