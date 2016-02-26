using System.Web.Mvc;

namespace TPV.Controllers
{
    public class VentasController : Controller
    {
        [Authorize(Roles = "User")]
        public ActionResult Index()
        {
            return View();
        }
    }
}