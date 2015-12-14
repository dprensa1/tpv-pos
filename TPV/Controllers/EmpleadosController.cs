using System.Web.Mvc;

namespace TPV.Controllers
{
    //[RoutePrefix("~/Empleados")]
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        [Route("Administracion/Empleados")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Administracion/Empleados/Detalles/5
        public ActionResult Detalles(int id)
        {
            return View();
        }

        // GET: Administracion/Empleados/Crear
        [Route("Administracion/Empleados/Crear")]
        public ActionResult Crear()
        {
            return View();
        }

        // POST: Administracion/Empleados/Crear
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

        // GET: Administracion/Empleados/Editar/5
        public ActionResult Editar(int id)
        {
            return View();
        }

        // POST: Administracion/Empleados/Editar/5
        [HttpPost]
        public ActionResult Editar(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administracion/Empleados/Borrar/5
        public ActionResult Borrar(int id)
        {
            return View();
        }

        // POST: Administracion/Empleados/Borrar/5
        [HttpPost]
        public ActionResult Borrar(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
