using System.Web.Mvc;
using System.Net;
using System;
using TPV.Models;
using TPV.Models.Repositories;

namespace TPV.Controllers
{
    public class EmpleadosController : Controller
    {
        EmpleadoRepositorio _EmpleadoRepositorio = new EmpleadoRepositorio();

        [HttpGet]
        public ViewResult Index(int PuestoID = 0)
        {
            //if (PuestoID >= 1)
            //    ViewBag.activoSeleccion = PuestoID;

            return View(_EmpleadoRepositorio.List);
        }

        // GET: Empleados/Detalles/5
        [HttpGet]
        public ActionResult Detalles(int id)
        {
            if (id >= 1)
            {
                Empleado empleado = _EmpleadoRepositorio.FindById(id);
                empleado.Sexo = empleado.Sexo.ToUpper();
                if (empleado == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }
                else
                {
                    switch (empleado.Sexo)
                    {
                        case "F":
                            empleado.Sexo = "Femenino";
                            break;
                        case "M":
                            empleado.Sexo = "Masculino";
                            break;
                        default:
                            empleado.Sexo = "No especificado";
                            break;
                    }

                    return View(empleado);
                }
            }
            else { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
        }

        // GET: Empleados/Crear
        public ActionResult Crear()
        {
            //ViewBag.Puestos = new SelectList(db.Puesto, "PuestoID", "Nombre") as IEnumerable<SelectList>;
            ViewBag.Puestos = new SelectList(new PuestoRepositorio().List, "PuestoID", "Nombre");

            return View();
        }

        // POST: Empleados/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Empleado empleado)
        {
            ViewBag.Puestos = new SelectList(new PuestoRepositorio().List, "PuestoID", "Nombre");
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
                    _EmpleadoRepositorio.Add(empleado);
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
                Empleado empleado = _EmpleadoRepositorio.FindById(id);

                if (empleado == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    ViewBag.Puestos = new SelectList(new PuestoRepositorio().List, "PuestoID", "Nombre");
                    return View(empleado);
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: Empleados/Editar/5
        [HttpPost]
        public ActionResult Editar(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _EmpleadoRepositorio.Update(empleado);
                return RedirectToAction("Index", new { empleado.EmpleadoID });
            }
            return View(empleado);
        }

        /*/ GET: Empleados/Borrar/5
        public ActionResult Borrar(int id)
        {
            return View();
        }*/

        // POST: Empleados/Borrar/5
        public ActionResult Borrar(int id)
        {
            if (id > 0)
            {
                _EmpleadoRepositorio.Delete(id);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return RedirectToAction("Index");

            /*try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }*/
        }
    }
}
