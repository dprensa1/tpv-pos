using System.Web.Mvc;
using TPV.Models.Repositorios;

namespace TPV.Controllers
{
    public class RolesController : Controller
    {
        RolRepositorio _RolRepositorio = new RolRepositorio();
        // GET: Roles
        public ActionResult Index()
        {
            return View(_RolRepositorio.List);
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