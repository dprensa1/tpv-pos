using System.Web.Mvc;
using TPV.Models;
using System.Linq;
using System.Collections.Generic;
using System.Net;

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
        [HttpGet]
        [Route("Administracion/Puestos/Detalles/{id:int}")]
        public ActionResult Detalles(int id)
        {
            char[] separador = { ';' };

            List<SelectListItem> funciones = new List<SelectListItem>();

            if (id != 0) {
                Puesto p = db.Puesto.Find(id);

                string[] funcs = p.Funciones.Split(separador, System.StringSplitOptions.RemoveEmptyEntries);

                foreach (var x in funcs)
                {
                    funciones.Add(new SelectListItem { Text = x, Value = x});
                }

                ViewData["funciones"] = funciones;

                if (p == null)
                {
                    return HttpNotFound();
                } else
                {
                    return View(p);
                }

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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