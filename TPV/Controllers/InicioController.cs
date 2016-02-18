using System.Web.Mvc;
using TPV.Models;

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