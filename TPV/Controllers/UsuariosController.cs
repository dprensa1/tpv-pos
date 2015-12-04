using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPV.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        [Route("Empleados/Usuarios")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Empleados/Usuarios/Crear
        [Route("Empleados/Usuarios/Crear")]
        public ActionResult Crear()
        {
            return View();
        }

        // GET: Empleados/Puestos/Crear
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