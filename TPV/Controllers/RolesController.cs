using System.Web.Mvc;
using TPV.Models;
using TPV.Models.Repositories;

namespace TPV.Controllers
{
    public class RolesController : Controller
    {
        LyraContext _RolRepositorio = new LyraContext();
        // GET: Roles
        public ActionResult Index()
        {
            return View(_RolRepositorio);
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