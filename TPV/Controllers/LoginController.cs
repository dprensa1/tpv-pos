using System.Linq;
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
            Login user = new Login();

            return View(user);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login usuario, string returnUrl)
        {
            if (ModelState.IsValid) { 
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
                }
            }
            else
            {
                return View(usuario);
            }
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