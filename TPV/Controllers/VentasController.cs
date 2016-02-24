using System.Web.Mvc;

namespace TPV.Controllers
{
    public class VentasController : Controller
    {
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}