﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPV.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        [Route("Productos")]
        public ActionResult Index()
        {
            return View();
        }
    }
}