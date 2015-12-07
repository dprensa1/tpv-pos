using System.Web.Mvc;

namespace TPV.Controllers
{
    public class PuestosController : Controller
    {
        // GET: Puestos
        [Route("Puestos")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Puestos/Crear
        [Route("Puestos/Crear")]
        public ActionResult Crear()
        {
            return View();
        }

        // GET: Puestos/Crear
        [HttpPost]
        public ActionResult Crear(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}