using System.Web.Mvc;

namespace TPV.Controllers
{
    public class AccesosController : Controller
    {
        // GET: Accesos
        [Route("Accesos")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Accesos/Crear
        [Route("Accesos/Crear")]
        public ActionResult Crear()
        {
            return View();
        }
    }
}