using System.Web.Mvc;

namespace TPV.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        [Route("Usuarios")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Empleados/Usuarios/Create
        [Route("Usuarios/Crear")]
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