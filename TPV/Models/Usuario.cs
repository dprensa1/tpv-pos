using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPV.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        public int EmpleadoID { get; set; }
        public virtual Empleado Empleado { get; set; }
        public string User { get; set; }
        public string Clave { get; set; }
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