using System.Web.Mvc;
using TPV.Models.Repositorios;

namespace TPV.Controllers
{
    public class ClientesController : Controller
    {
        ClienteRepositorio _ClienteRepositorio = new ClienteRepositorio();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(_ClienteRepositorio.List);
        }

        // GET: Clientes/Create
        public ActionResult Crear()
        {
            return View();
        }

        // GET: Clientes/Create
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