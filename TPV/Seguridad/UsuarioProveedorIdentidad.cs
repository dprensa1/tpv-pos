using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPV.Models;

namespace TPV.Seguridad
{
    public class UsuarioProveedorIdentidad : System.Web.Security.MembershipUser
    {
        public string User { get; set; }
        //public string Nombre { get; set; }
        //public string Cedula { get; set; }

        public UsuarioProveedorIdentidad(Usuario usuario)
        {
            User = usuario.User;
            //Nombre = usuario.Empleado.Nombre;
            //Cedula = usuario.Empleado.Cedula;
        }
    }
}