using System.Linq;
using System.Web.Mvc;
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
        [ValidateAntiForgeryToken]
        public ActionResult IniciarSesion(Login usuario)
        {
            if (validar(usuario))
                return Redirect("/Inicio");
            else
                return View("/Login");
        }

        private bool validar(Login usuario)
        {
            Lyra db = new Lyra();

            if (db.Usuario.FirstOrDefault(u => u.User.Equals(usuario.User) && u.Clave.Equals(usuario.Clave.ToString())) != null)
                return true;
            else
                return false;
        }
    }
}