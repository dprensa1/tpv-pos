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
        public ViewResult Index()
        {
            IEnumerable<Puesto> puestos = db.Puesto
                //.Where(where => where.Activo == true)
                .OrderBy(order => order.PuestoID);
            return View(puestos.ToList());
        }

        [HttpGet]
        public ActionResult Crear()
        {
            List<SelectListItem> funciones = new List<SelectListItem>();
            ViewData["Funciones"] = funciones;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Puesto puesto)
        {
            try
            {
                string[] text =
                {
                    puesto.PuestoID.ToString(),
                    puesto.Nombre,
                    puesto.Descripcion,
                    puesto.Funciones,
                    puesto.Activo.ToString()
                };                

                if (ModelState.IsValid)
                {
                    db.Puesto.Add(puesto);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(puesto);
                }
            }
            catch (Exception e /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator."+e.GetBaseException().ToString());
            }
            return View();
        }

        //[Route("Administracion/Puestos/Detalles/{id:int}")]
        [HttpGet]
        public ActionResult Detalles(int id)
        {
            if (id != 0) {
                Puesto puesto = db.Puesto.Find(id);
                if (puesto == null)
                { return HttpNotFound(); }
                else { return View(puesto); }
            }
            else { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
        }

        [HttpGet]
        //[Route("Administracion/Puestos/Editar/{id:int}")]
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
        public ActionResult Editar(Puesto puesto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puesto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(puesto);
        }

        private string PonerSaltos(string cadena)
        {
            string NuevaCadena = "";

            foreach (var x in cadena)
            {
                if (x.Equals(@"\n")) { NuevaCadena += x + ";"; }
                else { NuevaCadena += x; }
            }
            return NuevaCadena;
        }
    }
}