using System.Web.Mvc;
using TPV.Models.Repositorios;

namespace TPV.Controllers
{
    public class AccesosController : Controller
    {
        AccesoRepositorio _AccesoRepositorio = new AccesoRepositorio();

        [HttpGet]
        public ViewResult Index(int PuestoID = 0)
        {
            if (PuestoID >= 1)
                ViewBag.activoSeleccion = PuestoID;

            return View(_AccesoRepositorio.List);
        }

        // GET: Accesos/Crear
        public ActionResult Crear()
        {
            return View();
        }
    }
}