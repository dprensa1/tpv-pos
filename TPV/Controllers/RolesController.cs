using System.Web.Mvc;

namespace TPV.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        [Route("Administracion/Roles")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Roles/Crear
        [Route("Administracion/Roles/Crear")]
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