﻿using System.Web.Mvc;
using TPV.Models;

namespace TPV.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IniciarSesion([Bind(Include = "User,Clave")] Usuario login)
        {
            if (validar(login.User, login.Clave))
                return Redirect("Inicio");
            else
                return View("Login");
        }

        public ActionResult Main()
        {
            return View();
        }

        public bool validar(string user, string Clave)
        {
            Models.Usuario UsuarioLogin = new Models.Usuario();
            bool b = false;
            UsuarioLogin.User = "emarte";
            UsuarioLogin.Clave = "123456";
            if (UsuarioLogin.User.Equals(user) && UsuarioLogin.Clave.Equals(Clave))
                b = true;
            else
                b = false;
            return b;
        }
    }
}