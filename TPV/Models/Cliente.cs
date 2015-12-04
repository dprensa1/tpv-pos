using System;

namespace TPV.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Identificacion { get; set; }

        public string Telefono { get; set; }

        public string Contacto { get; set; }

        public string Telefono_Contacto { get; set; }

        public string Extension_Telefono_Contacto { get; set; }

        public int Codigo { get; set; }

        public char Estado { get; set; }

        //No se muestran en el formulario
        public char Estatus { get; set; }

        public DateTime FechaCreacion { get; set; }

        public virtual int UsuarioID { get; set; }

        public virtual Usuario CreadoPor { get; set; } //Usuario Actual logueado

    }
}