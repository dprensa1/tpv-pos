using System.Web.Mvc;

namespace TPV.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        [Route("Inicio")]
        public ActionResult Main()
        {
            return View();
        }
    }
}