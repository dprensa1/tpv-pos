using System.Web.Mvc;

namespace TPV.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}