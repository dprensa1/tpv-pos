using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TPV.Models;

namespace TPV.Controllers
{
    public class RolesController : Controller
    {
        private LyraContext db = new LyraContext();
        // GET: Roles
        public ActionResult Index()
        {
                IEnumerable<Rol> roles = db.Rol
                    .OrderBy(order => order.RolID);

                //if (PuestoID >= 1)
                //    ViewBag.activoSeleccion = PuestoID;

                return View(roles.ToList());
            }

        // GET: Roles/Crear
        public ActionResult Crear()
        {
            return View();
        }

        // GET: Administracion/Roles/Crear
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