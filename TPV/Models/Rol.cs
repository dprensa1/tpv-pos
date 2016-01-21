using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPV.Models
{
    [Table("Roles")]
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? RolID { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int? AccesoID { get; set; }

        [ForeignKey("AccesoID")]
        public virtual ICollection<Acceso> Accesos { get; set; }

        [ForeignKey("UsuarioID")]
        public virtual ICollection<Usuario> Usuarios { get; set; }

        [DefaultValue("1")]
        public bool Estado { get; set; }
    }
}