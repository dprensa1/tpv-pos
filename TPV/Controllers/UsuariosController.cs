using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TPV.Infrastructure.Validation;
using TPV.Models;

namespace TPV.Controllers
{
    public class UsuariosController : Controller
    {
        private UsuarioValidator _UsuarioValidator = new UsuarioValidator();

        public UsuariosController()
            : this(new UserManager<Usuario>(new UserStore<Usuario>(new LyraContext())))
        {
        }

        public UsuariosController(UserManager<Usuario> userManager)
        {
            UserManager = userManager;
        }

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
        public async Task<ActionResult> Crear(Usuario _Usuario)
        {
            ModelValidation<Usuario> UsuarioValidation = new ModelValidation<Usuario>(_Usuario, new UsuarioValidator());

            if (UsuarioValidation.Validate.IsValid)
            {
                var user = new Usuario { UserName = _Usuario.UserName };
                var result = await UserManager.CreateAsync(user, _Usuario.Clave);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var Error in result.Errors)
                    {
                        ModelState.AddModelError("", Error);
                    }
                    ModelState.AddModelError("", @"\nNo se pudo crear el usuario.");
                    return View(_Usuario);
                }
            }
            else
            {
                foreach (var Error in UsuarioValidation.Validate.Errors)
                {
                    ModelState.AddModelError(Error.PropertyName, Error.ErrorMessage);
                }
                return View(_Usuario);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Usuario _Usuario, string returnUrl)
        {
            ModelValidation<Usuario> UsuarioValidation = new ModelValidation<Usuario>(_Usuario, new UsuarioValidator());

            if (UsuarioValidation.Validate.IsValid)
            {
                var user = await UserManager.FindAsync(_Usuario.User, _Usuario.Clave);

                if (user != null)
                {
                    await SignInAsync(user);

                    ModelState.Remove("Clave");

                    return (Url.IsLocalUrl(returnUrl)) ? Redirect(returnUrl) : Redirect("~/Inicio");
                }

                ModelState.AddModelError("", "Usuario / Clave invalidos");
                return View(_Usuario);
            }
            else
            {
                foreach (var Error in UsuarioValidation.Validate.Errors)
                {
                    ModelState.AddModelError(Error.PropertyName, Error.ErrorMessage);
                }
                return View(_Usuario);
            }
        }

        [Authorize]
        public ActionResult Salir()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        public UserManager<Usuario> UserManager { get; private set; }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(Usuario user)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, identity);
        }
    }
}