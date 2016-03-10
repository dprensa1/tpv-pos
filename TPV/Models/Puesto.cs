using System.Collections.Generic;

namespace TPV.Models
{
    public class Puesto
    {
        public int PuestoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Funciones { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
        public bool Estado { get; set; }
        public string CreadoEn { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoEn { get; set; }
        public string ModificadoPor { get; set; }

        private string PonerSaltos(string cadena = "N/A")
        {
            string NuevaCadena = "";

            if (cadena.Equals(""))
                NuevaCadena = cadena != null ? cadena : "N/A";
            else
                NuevaCadena = cadena.Replace(";", "\n");

            return NuevaCadena;
        }

        private string QuitarSaltos(string cadena = "N/A")
        {
            string NuevaCadena = "";

            if (cadena.Equals(""))
                NuevaCadena = cadena != null ? cadena : "N/A";
            else
            {
                NuevaCadena = cadena.Replace("\r", ";");
                NuevaCadena = cadena.Replace("\n", ";");
            }

            return NuevaCadena;
        }
    }

    /*
        [Table("Puestos")]
    public class Puesto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? PuestoId { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "El Nombre debe tener entre 2 y 32 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Requerida")]
        [StringLength(128, MinimumLength = 8, ErrorMessage = "La Descripcion debe tener entre 8 y 128 caracteres")]
        public string Descripcion { get; set; }
        
        [NotMapped]
        private string _funciones;

        [Required(ErrorMessage = "Requerida")]
        [MinLength(2, ErrorMessage = "Debe tener al menos una funcion.")]
        public string Funciones
        {
            get { return _funciones; }
            set { _funciones = value; }
            //get { return PonerSaltos(funciones); }
            //set { funciones = QuitarSaltos(value); }
        }

        public virtual ICollection<Empleado> Empleados { get; set; }

        [DefaultValue("1")]        
        public bool Estado { get; set; }
        
        private string PonerSaltos(string cadena = "N/A")
        {
            string NuevaCadena = "";
            
            if(cadena.Equals(""))
                NuevaCadena = cadena != null ? cadena : "N/A";
            else
                NuevaCadena = cadena.Replace(";", "\n");

            return NuevaCadena;
        }

        private string QuitarSaltos(string cadena = "N/A")
        {
            string NuevaCadena = "";

            if (cadena.Equals(""))
                NuevaCadena = cadena != null ? cadena : "N/A";
            else
            {
                NuevaCadena = cadena.Replace("\r", ";");
                NuevaCadena = cadena.Replace("\n", ";");
            }

            return NuevaCadena;
        }

        public string CreadoEn { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoEn { get; set; }
        public string ModificadoPor { get; set; }
    }
    */


}