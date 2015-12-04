using System;

namespace TPV.Models
{
    public class Puesto
    {
        public int PuestoID { get; set; }

        public virtual string Nombre { get; set; }

        public virtual string Descripcion { get; set; }

        public char Estado { get; set; }

        //No se muestran en el formulario
        public char Estatus { get; set; }

        public DateTime FechaCreacion { get; set; }

        public virtual int UsuarioID { get; set; }

        public virtual Usuario CreadoPor { get; set; } //Usuario Actual logueado
    }
}