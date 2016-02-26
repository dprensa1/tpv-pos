using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TPV.Models
{
    public class Rol //: IdentityRole
    {
        public int RolId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int AccesoId { get; set; }
        public virtual ICollection<Acceso> Accesos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public bool Estado { get; set; }

        public string CreadoEn { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoEn { get; set; }
        public string ModificadoPor { get; set; }
    }

    /*
        [Table("Roles")]
    public class Rol //: IdentityRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RolId { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int? AccesoID { get; set; }

        [ForeignKey("AccesoID")]
        public virtual ICollection<Acceso> Accesos { get; set; }

        [ForeignKey("UsuarioID")]
        public virtual ICollection<Usuario> Usuarios { get; set; }

        [DefaultValue("1")]
        public bool Estado { get; set; }

        public string CreadoEn { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoEn { get; set; }
        public string ModificadoPor { get; set; }
    }
     */
}