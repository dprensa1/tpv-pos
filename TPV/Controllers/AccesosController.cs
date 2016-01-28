using System.Web.Mvc;
using TPV.Models;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System;
using System.Data.Entity;
namespace TPV.Controllers
{
    public class AccesosController : Controller
    {
        private LyraContext db = new LyraContext();

        [HttpGet]
        public ViewResult Index(int PuestoID = 0)
        {
            IEnumerable<Acceso> acceso = db.Acceso
                .OrderBy(order => order.AccesoID);

            if (PuestoID >= 1)
                ViewBag.activoSeleccion = PuestoID;

            return View(acceso.ToList());
        }

        // GET: Accesos/Crear
        public ActionResult Crear()
        {
            return View();
        }
    }
}