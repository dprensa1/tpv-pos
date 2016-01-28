using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPV.Models
{
    [Table("Accesos")]
    public class Acceso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? AccesoID { get; set; }

        [StringLength(16, MinimumLength = 4, ErrorMessage ="Debe tener entre 4 y 16 letras.")]
        [Required]
        public string Nombre { get; set; }

        [StringLength(128)]
        [Required]
        public string Descripcion { get; set; }
        
        [Required]
        public ICollection<string> Rutas { get; set; }

        public virtual ICollection<Rol> Roles { get; set; }

        [DefaultValue("1")]
        public bool Estado { get; set; }
    }
}