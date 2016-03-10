using System.Web.Mvc;
using TPV.Models.Repositories;

namespace TPV.Controllers
{
    public class AccesosController : Controller
    {
        AccesoRepositorio _AccesoRepositorio = new AccesoRepositorio();

        [HttpGet]
        public ViewResult Index(int PuestoId = 0)
        {
            if (PuestoId >= 1)
                ViewBag.activoSeleccion = PuestoId;

            return View(_AccesoRepositorio.List);
        }

        // GET: Accesos/Crear
        public ActionResult Crear()
        {
            return View();
        }
    }
}