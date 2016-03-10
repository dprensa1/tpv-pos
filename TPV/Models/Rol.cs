using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace TPV.Models
{
    public class Rol : IdentityRole
    {
        public int RolId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Acceso> Accesos { get; set; }
        public bool Estado { get; set; }
        public string CreadoEn { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoEn { get; set; }
        public string ModificadoPor { get; set; }
        public bool Status { get; set; }
    }
}