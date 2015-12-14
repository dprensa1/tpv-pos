using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPV.Models
{
    [Table("Empleados")]
    public class Empleado
    {
        [Key]
        public int EmpleadoID { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "El Nombre debe tener entre 2 y 32 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido requerido")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "El Apellido debe tener entre 2 y 32 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Sexo requerido")]
        public char Sexo { get; set; }

        [Required(ErrorMessage = "Fecha de nacimiento requerida")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required (ErrorMessage = "Cedula requerida")]
        [DataType(DataType.DateTime)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El Cedula debe tener solo 11 numeros")]
        [Index("Cedula_IDX", IsUnique = true)]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Telefono requerido")]
        [MinLength(10, ErrorMessage = "Telefono incompleto")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Telefono requerido")]
        [DataType(DataType.Currency)]
        public double Salario { get; set; }

        public int PuestoID { get; set; }

        [ForeignKey("PuestoEmpleado_FK")]
        public virtual Puesto Puesto { get; set; }

        //[]
        [ScaffoldColumn(false)]
        [Index("CodigoEmpleado_IDX", IsUnique = true)]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Fecha de Entrada requerida")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Entrada")]
        public DateTime FechaEntrada { get; set; }

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