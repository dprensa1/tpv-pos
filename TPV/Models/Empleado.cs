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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? EmpleadoID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Requerido.")]
        [RegularExpression(@"^[a-zA-Z ]+\w$", ErrorMessage = "Solo letras.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Deber tener entre 2 y 30 caracteres.")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Requerido.")]
        [RegularExpression(@"^[a-zA-Z ]+\w$", ErrorMessage = "Solo letras.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Deber tener entre 2 y 30 caracteres.")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Requerido.")]
        public char Sexo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Requerida.")]
        public DateTime FechaNacimiento { get; set; }

        [RegularExpression(@"^([0-9])+\w$", ErrorMessage = "Solo numeros.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Deber tener 11 numeros sin guiones")]
        [Required(ErrorMessage = "Requerida.")]
        [DataType(DataType.Text)]
        public string Cedula { get; set; }

        [Required(AllowEmptyStrings=false, ErrorMessage = "Requerido.")]
        [RegularExpression(@"^([0-9])+\w$", ErrorMessage = "Solo numeros.")]
        [DisplayName("Telefono / Celular")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Deber tener 10 numeros sin guiones")]
        public string Telefono { get; set; }

        [NotMapped]
        decimal _Salario;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Requerido.")]
        [Range(0.00, 150000.00, ErrorMessage ="Debe estar entre 0 y 150,000.00")]
        [RegularExpression(@"^([0-9])+\w$", ErrorMessage = "Solo numeros.")]
        public decimal Salario {
            get
            { return _Salario; }
            set
            { _Salario = value; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Requerido.")]
        public int PuestoID { get; set; }

        [ForeignKey("PuestoID")]
        public virtual Puesto Puesto { get; set; }

        [NotMapped]
        private int _Codigo;

        [Range(0, int.MaxValue)]
        [Index("CodigoIDX", IsUnique =true)]
        public int? Codigo
        {
            get
            { return _Codigo; }
            set
            { _Codigo++; }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FechaEntrada { get; set; }

        [DefaultValue("1")]
        public bool Activo { get; set; }

        public decimal quitarComa(double? Salario = 00.00)
        {
            string aux = Salario.ToString();
            string salida = "";
            foreach (char x in aux)
            {
                if (x.Equals(','))
                    salida += x;
            }
            return decimal.Parse(salida);
        }
        /*

        CREATE DEFINER = CURRENT_USER TRIGGER `lyra`.`empleados_BEFORE_INSERT` BEFORE INSERT ON `empleados`
        FOR EACH ROW
        BEGIN
            SET NEW.Codigo = (SELECT `EmpleadoID` FROM `empleados` ORDER BY `EmpleadoID` DESC LIMIT 1) + 1;
        END



        //No se muestran en el formulario
        public char Estatus { get; set; }

        [DatabaseGenerated(DatabaseGenerationOption.Computed)] 
        public DateTime FechaCreacion { get; set; }

        public int UsuarioID { get; set; }

        public virtual Usuario CreadoPor { get; set; }
        */
    }
}