using System.Web.Mvc;
using TPV.Models;
using System.Linq;
using System.Collections.Generic;

namespace TPV.Controllers
{
    public class PuestosController : Controller
    {
        private Lyra db = new Lyra();

        // GET: Administracion/Puestos
        [Route("Administracion/Puestos")]
        public ViewResult Index()
        {
            IEnumerable<Puesto> puestos = db.Puesto
                .Where(where => where.Estado == true)
                .OrderBy(order => order.PuestoID);

            return View(puestos.ToList());
        }

        // GET: Administracion/Puestos/Detalles
        [Route("Administracion/Puestos/Detalles/1")]
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {

            }

            Puesto p = db.Puesto.Find(id);

            if (p == null)
            { 

            }
            return View(p);
        }

        // GET: AdministracionPuestos/Crear
        [Route("Administracion/Puestos/Crear")]
        public ActionResult Crear()
        {
            return View();
        }

        // POST: Administracion/Puestos/Crear
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