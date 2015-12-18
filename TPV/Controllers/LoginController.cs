using System.Linq;
using System.Web.Mvc;
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
        public ActionResult IniciarSesion([Bind(Include = "User, Clave")] Usuario usuarioL)
        {
            if (validar(usuarioL))
                return Redirect("/Inicio");
            else
                return View("/Login");
        }

        private bool validar(Usuario usuarioL)
        {
            Lyra db = new Lyra();

            if (db.Usuarios.FirstOrDefault(u => u.User.Equals(usuarioL.User) && u.Clave.Equals(usuarioL.Clave.ToString())) != null)
                return true;
            else
                return false;
        }
    }
}