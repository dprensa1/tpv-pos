﻿using System.Web.Mvc;

namespace TPV.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        [Route("Empleados/Accesos")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Empleados/Usuarios/Create
        [Route("Empleados/Accesos/Crear")]
        public ActionResult Crear()
        {
            return View();
        }

        // GET: Empleados/Accesos/Create
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