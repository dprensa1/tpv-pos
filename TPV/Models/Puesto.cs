using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPV.Models
{
    [Table("Puestos")]
    public class Puesto
    {
        [Key]
        public int PuestoID { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "El Nombre de Usuario debe tener entre 2 y 32 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Descripcion requerida")]
        [StringLength(128, MinimumLength = 8, ErrorMessage = "El Nombre de Usuario debe tener entre 2 y 32 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Funcion/es requerida/s")]
        [MinLength(1, ErrorMessage = "Debe tener al menos 1 funcion a cargo")]
        [MaxLength(10, ErrorMessage = "Maximo 10 funciones a cargo")]
        public virtual ICollection<string> Funciones { get; set; }

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