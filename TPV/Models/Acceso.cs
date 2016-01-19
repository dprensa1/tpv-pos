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
        public string Rutas
        {
            get { return Rutas; }
            set
            {
                if (value.Equals("Todas"))
                    Rutas = "Todas";
                else
                    Rutas += value.ToString() + ";";
            }
        }
        public virtual ICollection<Rol> Roles { get; set; }

        [DefaultValue("true")]
        public bool Estado { get; set; }

        /*
        //No se muestran en el formulario
        public char Estatus { get; set; }

        [DatabaseGenerated(DatabaseGenerationOption.Computed)] 
        public DateTime FechaCreacion { get; set; }

        public int UsuarioID { get; set; }

        public virtual Usuario CreadoPor { get; set; }
        */
    }
}