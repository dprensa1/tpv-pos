using System;
using System.Collections.Generic;

namespace TPV.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }

        public virtual int EmpleadoID { get; set; }

        public virtual Empleado Empleado { get; set; }

        public string User { get; set; }

        public string Clave { get; set; }

        public List<Rol> Accesos { get; set; }

        public char Estado { get; set; }

        //No se muestran en el formulario
        public char Estatus { get; set; }

        public DateTime FechaCreacion { get; set; }

        //public virtual int UsuarioID { get; set; }

        public virtual Usuario CreadoPor { get; set; } //Usuario Actual logueado
    }
}