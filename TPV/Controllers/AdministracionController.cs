using System.Web.Mvc;

namespace TPV.Controllers
{
    public class AdministracionController : Controller
    {
        // GET: Administration
        [Route("Administracion")]
        public ActionResult Index()
        {
            return View();
        }
    }
}