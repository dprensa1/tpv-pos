using System;
using TPV.Infrastructure.Validation;

namespace TPV.Models
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public decimal Salario { get; set; }
        public int PuestoId { get; set; }
        public virtual Puesto Puesto { get; set; }
        public int Codigo { get; set; }
        public DateTime FechaEntrada { get; set; }
        public bool Estado { get; set; }
        public string CreadoEn { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoEn { get; set; }
        public string ModificadoPor { get; set; }
    }
}


/*
    [Table("Empleados")]
     {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpleadoId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Requerido.")]
        [RegularExpression(@"/[a-zA-Z ]+\w/g", ErrorMessage = "Solo letras.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Deber tener entre 2 y 30 caracteres.")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Requerido.")]
        [RegularExpression(@"/[a-zA-Z ]+\w/g", ErrorMessage = "Solo letras.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Deber tener entre 2 y 30 caracteres.")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Requerido.")]
        [StringLength(1, MinimumLength = 1)]
        [DefaultValue('N')]
        public string Sexo { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Debe ser una fecha del modo: Mes/Dia/Año")]
        [Column(TypeName = "Date")]
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
        [Range(0.00, 200000.00, ErrorMessage ="Debe estar entre 0 y 200,000.00")]
        [RegularExpression(@"^([0-9])+\w$", ErrorMessage = "Solo numeros.")]
        public decimal Salario {
            get
            { return quitarComa(_Salario); }
            set
            { _Salario = value; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Requerido.")]
        public int PuestoId { get; set; }

        [ForeignKey("PuestoId")]
        public virtual Puesto Puesto { get; set; }

        [NotMapped]
        private int? _Codigo;
        
        [Index("CodigoIDX", IsUnique =true)]
        [DefaultValue(0)]
        public int? Codigo
        {
            get
            { return _Codigo; }
            set
            {
                _Codigo = value;
            }
            //{ _Codigo = (value == null) ? 0 : value; }
        }

        [DataType(DataType.Date, ErrorMessage = "Debe ser una fecha del modo: Mes/Dia/Año")]
        [Column(TypeName = "Date")]
        [DefaultValue("2016/01/01")]
        public DateTime FechaEntrada { get; set; }

        [DefaultValue("1")]
        public bool Estado { get; set; }

        public decimal quitarComa(decimal Salario = 00)
        {
            char [] aux = Salario.ToString().ToCharArray();
            string salida = "";
            foreach (char x in aux)
            {
                if (x.Equals(','))
                    if (x.Equals('0'))
                        if (x.Equals('0'))
                            break;
                        else
                            break;
                    else
                        break;
                else
                    salida += x;
            }
            return decimal.Parse(salida);
        }

        public string CreadoEn { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoEn { get; set; }
        public string ModificadoPor { get; set; }
        /*
        CREATE DEFINER = CURRENT_USER TRIGGER `lyra`.`empleados_BEFORE_INSERT`
        BEFORE INSERT ON `empleados`
        FOR EACH ROW
        BEGIN
            SET NEW.Codigo = (SELECT `EmpleadoId` FROM `empleados` ORDER BY `EmpleadoId` DESC LIMIT 1) + 1;
        END
        
    }
 */