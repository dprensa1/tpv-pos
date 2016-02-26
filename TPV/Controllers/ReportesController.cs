using System.Web.Mvc;

namespace TPV.Controllers
{
    public class ReportesController : Controller
    {
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}