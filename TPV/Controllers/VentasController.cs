using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPV.Controllers
{
    public class VentasController : Controller
    {
        [Authorize(Roles = "Administrator, KingOnRails")]
        public ActionResult Index()
        {
            return View();
        }
    }
}