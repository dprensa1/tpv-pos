using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPV.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        [Route("Inicio")]
        public ActionResult Main()
        {
            return View();
        }
    }
}