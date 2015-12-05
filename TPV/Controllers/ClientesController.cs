using System.Web.Mvc;

namespace TPV.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        [Route("Clientes")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Clientes/Create
        [Route("Clientes/Crear")]
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