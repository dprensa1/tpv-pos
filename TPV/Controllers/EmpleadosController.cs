using System.Web.Mvc;
using TPV.Models;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Data.Entity;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace TPV.Controllers
{
    public class EmpleadosController : Controller
    {
        private Lyra db = new Lyra();

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Empleado> empleados = db.Empleado
                .OrderBy(order => order.PuestoID);

            return View(empleados.ToList());
        }

        // GET: Administracion/Empleados/Detalles/5
        public ActionResult Detalles(int id)
        {
            return View();
        }

        // GET: Administracion/Empleados/Crear
        public ActionResult Crear()
        {
            ViewBag.PuestoID = new SelectList(db.Puesto, "PuestoID", "Nombre");

            return View();
        }

        // POST: Administracion/Empleados/Crear
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

        // GET: Administracion/Empleados/Editar/5
        public ActionResult Editar(int id)
        {
            return View();
        }

        // POST: Administracion/Empleados/Editar/5
        [HttpPost]
        public ActionResult Editar(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administracion/Empleados/Borrar/5
        public ActionResult Borrar(int id)
        {
            return View();
        }

        // POST: Administracion/Empleados/Borrar/5
        [HttpPost]
        public ActionResult Borrar(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
