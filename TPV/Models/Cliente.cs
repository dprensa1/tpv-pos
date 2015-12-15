using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPV.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "El Nombre debe tener entre 2 y 32 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido requerido")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "El Apellido debe tener entre 2 y 32 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Identificacion requerida")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "Telefono requerido")]
        [MinLength(10, ErrorMessage = "Telefono incompleto")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Contacto requerido")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "El nombre del Contacto debe tener entre 2 y 32 caracteres")]
        public string Contacto { get; set; }

        [Required(ErrorMessage = "Telefono requerido")]
        [MinLength(10, ErrorMessage = "Telefono del Contacto incompleto")]
        public string Telefono_Contacto { get; set; }

        public string Extension_Telefono_Contacto { get; set; }

        //[]
        [ScaffoldColumn(false)]
        [Index("CodigoCliente_IDX", IsUnique = true)]
        public int Codigo { get; set; }

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