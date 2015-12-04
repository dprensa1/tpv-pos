using System.Web.Mvc;

namespace TPV.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        [Route("Reportes")]
        public ActionResult Index()
        {
            return View();
        }
    }
}