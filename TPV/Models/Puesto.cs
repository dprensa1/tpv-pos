using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPV.Models
{
    [Table("Puestos")]
    public class Puesto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? PuestoID { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "El Nombre debe tener entre 2 y 32 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Requerida")]
        [StringLength(128, MinimumLength = 8, ErrorMessage = "La Descripcion debe tener entre 8 y 128 caracteres")]
        public string Descripcion { get; set; }
        
        [NotMapped]
        private string funciones;

        [Required(ErrorMessage = "Requerida")]
        [MinLength(2, ErrorMessage = "Debe tener al menos una funcion.")]
        public string Funciones
        {
            get { return funciones; }
            set { funciones = value; }
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