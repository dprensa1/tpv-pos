using System.Web.Mvc;
using System.Collections.Generic;
using System.Net;
using System;
using TPV.Models;
using TPV.Models.Repositorios;

namespace TPV.Controllers
{
    public class PuestosController : Controller
    {
        PuestoRepositorio _PuestoRepositorio = new PuestoRepositorio();

        private LyraContext db = new LyraContext();

        [HttpGet]
        public ViewResult Index(int PuestoID = 0)
        {
            if (PuestoID >= 1)
                ViewBag.activoSeleccion = PuestoID;

            return View(_PuestoRepositorio.List);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            try
            {
                //List<SelectListItem> funciones = new List<SelectListItem>();
                ViewData["Funciones"] = /*funciones;*/ new List<SelectListItem>();
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

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
                    puesto.Estado.ToString()
                };

                if (ModelState.IsValid)
                {
                    _PuestoRepositorio.Add(puesto);

                    return RedirectToAction("Index", new { puesto.PuestoID });
                }
                else
                {
                    ModelState.AddModelError("", "No se puede guardar.");
                    return View(puesto);
                }
            }
            catch (Exception e /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "No se puede guardar." + e.GetBaseException());
            }
            ViewBag.activoSeleccion = puesto.PuestoID;
            return View();
        }

        //[Route("Administracion/Puestos/Detalles/{id:int}")]
        [HttpGet]
        public ActionResult Detalles(int id)
        {
            if (id != 0) {
                Puesto puesto = _PuestoRepositorio.FindById(id);

                if (puesto == null)
                    return HttpNotFound();
                else
                    return View(puesto);

            }
            else { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
        }

        [HttpGet]
        //[Route("Administracion/Puestos/Editar/{id:int}")]
        public ActionResult Editar(int id)
        {
            char[] separador = { ';' };

            List<SelectListItem> funciones = new List<SelectListItem>();

            if (id > 0)
            {
                Puesto p = _PuestoRepositorio.FindById(id);

                string[] funcs = p.Funciones.Split(
                    separador, System.StringSplitOptions.RemoveEmptyEntries);

                foreach (var x in funcs)
                {
                    funciones.Add(new SelectListItem { Text = x, Value = x });
                }

                ViewData["funciones"] = funciones;

                if (p == null)
                    return HttpNotFound();
                else
                    return View(p);
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
                _PuestoRepositorio.Update(puesto);
                return RedirectToAction("Index", new { puesto.PuestoID });
            }
            return View(puesto);
        }
        
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Borrar(int id)
        {
            if (id > 0)
            {
                _PuestoRepositorio.Delete(id);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return RedirectToAction("Index");
        }
    }
}