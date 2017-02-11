using PSTodos.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PSTodos.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsuarioApplication _usuarioApplication;

        public HomeController(UsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }
        public ActionResult Index()
        {
            var usuario = _usuarioApplication.Obter(1);
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
