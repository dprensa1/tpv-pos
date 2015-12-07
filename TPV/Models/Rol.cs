using System;
using System.Collections.Generic;

namespace TPV.Models
{
    public class Rol
    {
        public int RolID { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public List<String> Accesos { get; set; }

        public char Estado { get; set; }

        //No se muestran en el formulario
        public char Estatus { get; set; }

        public DateTime FechaCreacion { get; set; }

        public virtual int UsuarioID { get; set; }

        public virtual Usuario CreadoPor { get; set; } 

    }
}