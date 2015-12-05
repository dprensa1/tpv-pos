using System.Web.Mvc;

namespace TPV.Controllers
{
    public class PuestosController : Controller
    {
        // GET: Puestos
        [Route("Empleados/Puestos")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Empleados/Puestos/Create
        [Route("Empleados/Puestos/Crear")]
        public ActionResult Crear()
        {
            return View();
        }

        // GET: Empleados/Puestos/Create
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