using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPV.Models
{
    [Table("Accesos")]
    public class Acceso
    {
        public int AccesoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Rutas { get; set; }
        public virtual ICollection<Rol> Roles { get; set; }
        public bool Estado { get; set; }
        public string CreadoEn { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoEn { get; set; }
        public string ModificadoPor { get; set; }
    }
}