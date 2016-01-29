using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using TPV.Models;

namespace TPV.Controllers
{
    public class LoginController : Controller
    {        
        // GET: Login
        public ActionResult Index()
        {

            return View(new Login());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login usuario, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(usuario.User, usuario.Clave))
                {
                    FormsAuthentication.SetAuthCookie(usuario.User, true);
                    FormsAuthentication.RedirectFromLoginPage(usuario.User, false);
                    return Redirect("~/Inicio");
                }
                else
                {
                    ModelState.AddModelError("", "Su Usuario o Contraseña estan incorrectos");
                    return Redirect("~/Login");
                }
                /*
                if (validar(usuario))
                {
                    FormsAuthentication.SetAuthCookie(usuario.User.ToString(), true);

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 
                        && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return Redirect("/Inicio");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Su Usuario o Contraseña estan incorrectos");
                    return View(usuario);
                }*/
            }
            else
            {
                ModelState.AddModelError("", "Su Usuario o Contraseña estan incorrectos");
                return View(usuario);
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return Redirect("~/Login");
        }

        private bool validar(Login usuario)
        {
            LyraContext db = new LyraContext();

            if (db.Usuario.FirstOrDefault(u => u.User.Equals(usuario.User) && u.Clave.Equals(usuario.Clave.ToString())) != null)
                return true;
            else
                return false;
        }
    }
}