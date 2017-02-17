using PSTodos.Mvc.Notifications;
using PSTodos.RESTServices;
using PSTodos.RESTServices.ViewModels;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace PSTodos.Mvc.Controllers
{
    public class PerfisController : Controller
    {
        private readonly IPerfilRESTService _service;

        public PerfisController(IPerfilRESTService service)
        {
            _service = service;
        }
        // GET: Perfis
        public ActionResult Index()
        {
            var vm = _service.Listar();
            return View(vm.Result);
        }

        public ActionResult Create()
        {
            var vm = new PerfilViewModel();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(PerfilViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                this.AddToastMessage("", "Falha ao cadastrar Perfil.", ToastType.Error);
                return View("Create", vm);
            }

            var result = _service.Cadastrar(vm);

            if (result.Success)
            {
                this.AddToastMessage("", "Perfil cadastrado com sucesso.", ToastType.Success);
                return RedirectToAction("Index");
            }
            else
            {
                this.AddToastMessage("", "Falha ao cadastrar Perfil.", ToastType.Error);
                return View("Create", vm);
            }
        }

        public ActionResult Edit(int id)
        {
            var vm = _service.Obter(id);

            return View("Edit", vm.Result);
        }

        [HttpPut]
        public ActionResult Edit(int id, PerfilViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                this.AddToastMessage("", "Falha ao alterar Perfil.", ToastType.Error);
                return View("Edit", vm);
            }

            var result = _service.Editar(id, vm);

            if (result.Success)
            {
                this.AddToastMessage("", "Perfil alterado com sucesso.", ToastType.Success);
                return RedirectToAction("Index");
            }
            else
            {
                this.AddToastMessage("", "Falha ao Alterar Perfil.", ToastType.Error);
                return View("Edit", vm);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var result = _service.Remover(id);

            if(result.Success)
                this.AddToastMessage("", "Perfil removido com sucesso.", ToastType.Success);
            else
                this.AddToastMessage("", "Falha ao remover perfil.", ToastType.Success);
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult ListarPerfis()
        {
            var vm = _service.Listar();
            
            return PartialView("_ListarPerfisPartial", vm.Result);
        }
    }
}