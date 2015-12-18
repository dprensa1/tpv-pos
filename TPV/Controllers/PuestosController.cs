using System.Web.Mvc;
using TPV.Models;
using System.Linq;
using System.Collections.Generic;

namespace TPV.Controllers
{
    public class PuestosController : Controller
    {
        // GET: Puestos
        [Route("Administracion/Puestos")]
        public ActionResult Index()
        {
            Lyra db = new Lyra();

            IEnumerable<Puesto> puestos = db.Puesto
                .Where(where => where.Estado == true)
                .OrderBy(order => order.PuestoID);

            puestos.ToString();

            return View(puestos.ToList());
        }

        // GET: Puestos/Crear
        [Route("Administracion/Puestos/Crear")]
        public ActionResult Crear()
        {
            return View();
        }

        // GET: Administracion/Puestos/Crear
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