using System.Web.Mvc;

namespace TPV.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}