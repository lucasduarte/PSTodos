using PSTodos.Mvc.Notifications;
using PSTodos.RESTServices;
using PSTodos.RESTServices.ViewModels;
using System;
using System.Web.Mvc;

namespace PSTodos.Mvc.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRESTService _service;

        public UsuariosController(IUsuarioRESTService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            var vm = _service.Listar();

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
                this.AddToastMessage("", "Falha ao cadastrar Usuário.", ToastType.Error);
                return View("Create", vm);
            }

            var result = _service.Cadastrar(vm);

            if(result.Success)
            {
                this.AddToastMessage("", "Usuário cadastrado com sucesso.", ToastType.Success);
                return RedirectToAction("Edit", new { id = result.Result.Id });
            }
            else
            {
                this.AddToastMessage("", "Falha ao cadastrar Usuário.", ToastType.Error);
                return View("Create", vm);
            }
        } 

        public ActionResult Edit(int id)
        {
            var vm = _service.Obter(id);

            return View("Edit", vm.Result);
        }

        [HttpPut]
        public ActionResult Edit(int id, UsuarioViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                this.AddToastMessage("", "Falha ao alterar Usuário.", ToastType.Error);
                return View("Edit", vm);
            }

            var result = _service.Editar(id, vm);

            if(result.Success)
            {
                this.AddToastMessage("", "Usuário alterado com sucesso.", ToastType.Success);
                return RedirectToAction("Index");
            }
            else
            {
                this.AddToastMessage("Erro", "Falha ao alterar Usuário.", ToastType.Error);
                return View("Edit", vm);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var result = _service.Remover(id);

            if(result.Success)
                this.AddToastMessage("", "Usuário removido com sucesso.", ToastType.Success);
            else
                this.AddToastMessage("", "Falha ao remover Usuário.", ToastType.Success);
            return RedirectToAction("Index");
        }
    }

}