using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPV.Models
{
    [Table("Empleado")]
    public class Empleado
    {
        [Key]
        public int EmpleadoID { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        [MinLength(3, ErrorMessage ="El Nombre debe tener al menos 3 letras")]
        [MaxLength(30, ErrorMessage = "El Nombre no puede exceder 30 letras")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido requerido")]
        [MinLength(3, ErrorMessage = "El Apellido debe tener al menos 3 letras")]
        [MaxLength(30, ErrorMessage = "El Apellido no puede exceder 30 letras")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Sexo requerido")]
        public char Sexo { get; set; }

        [Required(ErrorMessage = "Fecha de nacimiento requerido")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required (ErrorMessage = "Cedula requerida")]
        [DataType(DataType.DateTime)]
        [MinLength(11, ErrorMessage = "Cedula incompleta")]
        [MaxLength(11, ErrorMessage = "La Cedula excede la cantidad")]
        [Index("Cedula_IDX", IsUnique = true)]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Telefono requerido")]
        [DataType(DataType.DateTime)]
        [MinLength(11, ErrorMessage = "Cedula incompleeta")]
        [MaxLength(11, ErrorMessage = "La Cedula excede la cantidad")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Telefono requerido")]
        [DataType(DataType.Currency)]
        public double Salario { get; set; }

        public int PuestoID { get; set; }

        [ForeignKey("PuestoID_FK")]
        public virtual Puesto Puesto { get; set; }

        //[]
        [ScaffoldColumn(false)]
        [Index("Codigo_IDX", IsUnique = true)]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Fecha de Entrada requerida")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Entrada")]
        public DateTime FechaEntrada { get; set; }
        
        [Required]
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