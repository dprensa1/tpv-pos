using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPV.Models
{
    [Table("Accesos")]
    public class Acceso
    {
        [Key]
        public int AccesoID { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "El Nombre de debe tener entre 4 y 32 caracteres")]
        [Index(IsUnique = true)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "URL de Acceso requerida")]
        [MinLength(1, ErrorMessage = "Debe tener al menos 1 funcion a cargo")]
        [MaxLength(10, ErrorMessage = "Maximo 10 funciones a cargo")]
        public virtual ICollection<string> AccesosURL { get; set; }

        [Required(ErrorMessage = "Estado requerido")]
        public char Estado { get; set; }

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