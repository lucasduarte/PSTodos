using System.Web.Mvc;

namespace PSTodos.Mvc.Controllers
{
    public class HomeController : Controller
    {  
        public ActionResult Index()
        {
            return View();
        }
    }
}