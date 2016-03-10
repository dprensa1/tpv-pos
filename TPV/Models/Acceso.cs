using System.Collections.Generic;

namespace TPV.Models
{
    public class Acceso
    {
        public int AccesoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Rutas { get; set; }
        public virtual ICollection<Rol> Rols { get; set; }
        public bool Estado { get; set; }
        public string CreadoEn { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoEn { get; set; }
        public string ModificadoPor { get; set; }
    }
}