using System.Web.Mvc;

namespace TPV.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        [Route("Inicio")]
        [Authorize]
        public ActionResult Main()
        {
            return View();
        }
    }
}