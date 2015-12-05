using System.Web.Mvc;

namespace TPV.Controllers
{
    //[RoutePrefix("~/Empleados")]
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        [Route("Empleados")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Empleados/Detalles/5
        public ActionResult Detalles(int id)
        {
            return View();
        }

        // GET: Empleados/Crear
        public ActionResult Crear()
        {
            return View();
        }

        // POST: Empleados/Crear
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

        // GET: Empleados/Editar/5
        public ActionResult Editar(int id)
        {
            return View();
        }

        // POST: Empleados/Editar/5
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

        // GET: Empleados/Borrar/5
        public ActionResult Borrar(int id)
        {
            return View();
        }

        // POST: Empleados/Borrar/5
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
