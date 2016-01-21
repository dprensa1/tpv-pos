using System.Web.Mvc;
using TPV.Models;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System;

namespace TPV.Controllers
{
    public class EmpleadosController : Controller
    {
        private Lyra db = new Lyra();

        [HttpGet]
        public ViewResult Index(int PuestoID = 0)
        {
            IEnumerable<Empleado> empleados = db.Empleado
                .OrderBy(order => order.PuestoID);

            if (PuestoID >= 1)
                ViewBag.activoSeleccion = PuestoID;

            return View(empleados.ToList());
        }

        // GET: Empleados/Detalles/5
        [HttpGet]
        public ActionResult Detalles(int id)
        {
            if (id != 0)
            {
                Empleado empleado = db.Empleado.Find(id);
                if (empleado == null) { return HttpNotFound(); }
                else { return View(empleado); }
            }
            else { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
        }

        // GET: Empleados/Crear
        public ActionResult Crear()
        {
            //ViewBag.Puestos = new SelectList(db.Puesto, "PuestoID", "Nombre") as IEnumerable<SelectList>;
            ViewBag.Puestos = new SelectList(db.Puesto, "PuestoID", "Nombre");

            return View();
        }

        // POST: Empleados/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Empleado empleado)
        {

            ViewBag.Puestos = new SelectList(db.Puesto, "PuestoID", "Nombre");
            //string[] text =
            //    {
            //        empleado.EmpleadoID.ToString(),
            //        empleado.Nombre,
            //        empleado.Apellido,
            //        empleado.Sexo.ToString(),
            //        empleado.FechaNacimiento.ToString(),
            //        empleado.Cedula,
            //        empleado.Telefono,
            //        empleado.Salario.ToString(),
            //        empleado.PuestoID.ToString(),
            //        empleado.Codigo.ToString(),
            //        empleado.FechaEntrada.ToString(),
            //        empleado.Activo.ToString()
            //    };
            try
            {
                if (ModelState.IsValid)
                {
                    db.Empleado.Add(empleado);
                    db.SaveChanges();
                    return RedirectToAction("Index", new { empleado.EmpleadoID });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se puede guardar.");
                    return View(empleado);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("unError", e.InnerException.InnerException.Message);
            }

            return View();
        }

        // GET: Empleados/Editar/5
        public ActionResult Editar(int id)
        {
            if (id > 0)
            {
                Empleado Empleado = db.Empleado.Find(id);

                if (Empleado == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    ViewBag.Puestos = new SelectList(db.Puesto, "PuestoID", "Nombre");
                    return View(Empleado);
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: Empleados/Editar/5
        [HttpPost]
        public ActionResult Editar(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index"/*, new { empleado.EmpleadoID }*/);
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleados/Borrar/5
        public ActionResult Borrar(int id)
        {
            return View();
        }

        // POST: Empleados/Borrar/5
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
