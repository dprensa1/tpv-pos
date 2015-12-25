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

        // GET: Administracion/Empleados/Crear
        public ActionResult Crear()
        {
            //ViewBag.Puestos = new SelectList(db.Puesto, "PuestoID", "Nombre") as IEnumerable<SelectList>;
            ViewBag.Puestos = new SelectList(db.Puesto, "PuestoID", "Nombre");

            return View();
        }

        // POST: Administracion/Empleados/Crear
        [HttpPost]
        public ActionResult Crear(Empleado empleado)
        {
            ViewBag.Puestos = new SelectList(db.Puesto, "PuestoID", "Nombre");

            try
            {
                string[] text =
                {
                    empleado.EmpleadoID.ToString(),
                    empleado.Nombre,
                    empleado.Apellido,
                    empleado.Sexo.ToString(),
                    empleado.FechaNacimiento.ToString(),
                    empleado.Cedula,
                    empleado.Telefono,
                    empleado.Salario.ToString(),
                    empleado.PuestoID.ToString(),
                    empleado.Codigo.ToString(),
                    empleado.FechaEntrada.ToString(),
                    empleado.Activo.ToString()
                };

                if (ModelState.IsValid)
                {
                    db.Empleado.Add(empleado);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(empleado);
                }
            }
            catch (Exception e /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View();
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
