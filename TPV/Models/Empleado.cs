using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPV.Models
{
    [Table("Empleados")]
    public class Empleado
    {
        [Key]
        public int EmpleadoID { get; set; }

        [Required(/*AllowEmptyStrings = false, */ErrorMessage = "Nombre requerido.")]
        [RegularExpression(@"^[a-zA-Z ]+\w$", ErrorMessage = "Solo puede contener letras.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Deber tener entre 2 y 30 caracteres.")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Apellido requerido.")]
        [RegularExpression(@"^[a-zA-Z ]+\w$", ErrorMessage = "Solo puede contener letras.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Deber tener entre 2 y 30 caracteres.")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Sexo requerido.")]
        public char Sexo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fecha de Nacimiento requerida.")]
        public DateTime FechaNacimiento { get; set; }

        [RegularExpression(@"/([0-9])/gi", ErrorMessage = "Solo puede contener numeros.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = ("{0:###-#######-#}"))]
        [StringLength(11,MinimumLength = 11, ErrorMessage = "Deber tener 11 numeros sin guiones")]
        [Required(ErrorMessage = "Cedula requerida.")]
        public string Cedula { get; set; }

        [Required(AllowEmptyStrings=false, ErrorMessage ="Numero de telefono o celular requerido.")]
        [RegularExpression(@"/([0-9])/gi", ErrorMessage = "Solo puede contener numeros.")]
        [DisplayName("Telefono / Celular")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString =("{0:(###)-###-####}"))]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Deber tener 10 numeros sin guiones")]
        public string Telefono { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Solo puede contener numeros.")]
        [RegularExpression(@"/([0-9])/gi", ErrorMessage = "Solo puede contener numeros.")]
        public double Salario { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Puesto requerido.")]
        public int PuestoID { get; set; }

        [ForeignKey("PuestoID.")]
        public virtual ICollection<Puesto> Puesto { get; set; }

        [DefaultValue("00000.")]
        public int Codigo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}.")]
        public DateTime FechaEntrada { get; set; }

        [DefaultValue("1.")]
        public bool Activo { get; set; }

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