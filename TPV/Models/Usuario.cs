using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace TPV.Models
{
    public class Usuario : IdentityUser
    {
        public int UsuarioId { get; set; }
        public int EmpleadoId { get; set; }
        public virtual Empleado Empleado { get; set; }
        public string User { get; set; }
        public string Clave { get; set; }
        public virtual ICollection<Rol> Rols { get; set; }
        public bool Estado { get; set; }
        public string CreadoEn { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoEn { get; set; }
        public string ModificadoPor { get; set; }
    }
}