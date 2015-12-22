using System.Web.Mvc;
using TPV.Models;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Data.Entity;
using System;

namespace TPV.Controllers
{
    public class PuestosController : Controller
    {
        private Lyra db = new Lyra();

        [HttpGet]
        [Route("Administracion/Puestos")]
        public ViewResult Index()
        {
            IEnumerable<Puesto> puestos = db.Puesto
                .Where(where => where.Estado == true)
                .OrderBy(order => order.PuestoID);

            return View(puestos.ToList());
        }

        [HttpGet]
        [Route("Administracion/Puestos/Crear")]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "Nombre, Descripcion, Funciones, Estado")]Puesto puesto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Puesto.Add(puesto);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View();
        }

        [HttpGet]
        [Route("Administracion/Puestos/Detalles/{id:int}")]
        public ActionResult Detalles(int id)
        {
            char[] separador = { ';' };

            List<SelectListItem> funciones = new List<SelectListItem>();

            if (id != 0) {
                Puesto p = db.Puesto.Find(id);

                string[] funcs = p.Funciones.Split(separador, System.StringSplitOptions.RemoveEmptyEntries);

                foreach (var x in funcs)
                {
                    funciones.Add(new SelectListItem { Text = x, Value = x });
                }
                ViewData["funciones"] = funciones;

                if (p == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(p);
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("Administracion/Puestos/Editar/{id:int}")]
        public ActionResult Editar(int id)
        {
            char[] separador = { ';' };

            List<SelectListItem> funciones = new List<SelectListItem>();

            if (id != 0)
            {
                Puesto p = db.Puesto.Find(id);

                string[] funcs = p.Funciones.Split(separador, System.StringSplitOptions.RemoveEmptyEntries);

                foreach (var x in funcs)
                {
                    funciones.Add(new SelectListItem { Text = x, Value = x });
                }

                ViewData["funciones"] = funciones;

                if (p == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(p);
                }

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Nombre,Descripcion,Funciones,Estado")] Puesto puesto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puesto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(puesto);
        }

    }
}