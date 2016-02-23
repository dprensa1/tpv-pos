using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using TPV.Models.Repositories;
using TPV.ViewModels;
using TPV.Security;

namespace TPV.Controllers
{
    public class UsuariosController : Controller
    {
        ProveedorMembresia _ProveedorMembreria = new ProveedorMembresia();
        UsuarioRepositorio _UsuarioRepositorio = new UsuarioRepositorio();
        AccesoRepositorio _AccesoRepositorio = new AccesoRepositorio();

        public UsuariosController() { }

        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crear()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Crear(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login usuario, string returnUrl = "" )
        {

            if (ModelState.IsValid)
            {
                var userValid = _ProveedorMembreria.ValidateUser(usuario.User, usuario.Clave);

                if (userValid)
                {
                    FormsAuthentication.SetAuthCookie(usuario.User, false);

                    ModelState.Remove("Clave");

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return Redirect("~/Inicio");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Su Usuario o Contraseña estan incorrectos");
                return Redirect("~/Usuarios/Login");
            }

            ModelState.Remove("Clave");
            return View();
        }
      
        [Authorize]
        public ActionResult Salir()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        private bool validar(Login usuario)
        {
            if (new Models.LyraContext().Usuarios.FirstOrDefault( u => u.User.Equals(usuario.User) && u.Clave.Equals(usuario.Clave.ToString())) != null)
                return true;
            else
                return false;
        }
    }
}