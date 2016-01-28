using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPV.Seguridad
{
    public class ProvedorUsuarioMembresia : System.Web.Security.MembershipUser
    {
        public string Nombre { get; set; }

        public ProvedorUsuarioMembresia(Models.Usuario usuario)
        {
            Nombre = usuario.User;
        }
    }
}