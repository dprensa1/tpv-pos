using System.Collections.Generic;

namespace TPV.Models
{
    public class Acceso
    {
        public int AccesoID { get; set; }

        public string Nombre { get; set; }

        public virtual ICollection<string> AccesosURL { get; set; }

        public char Estado { get; set; }

        //No se muestran en el formulario
        public char Estatus { get; set; }

        public System.DateTime FechaCreacion { get; set; }

        public int UsuarioID { get; set; }

        public virtual Usuario CreadoPor { get; set; }
    }
}