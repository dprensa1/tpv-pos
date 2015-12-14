using System.Web.Mvc;

namespace TPV.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        [Route("Administracion/Usuarios")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Usuarios/Create
        [Route("Administracion/Usuarios/Crear")]
        public ActionResult Crear()
        {
            return View();
        }

        // GET: Administracion/Puestos/Create
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