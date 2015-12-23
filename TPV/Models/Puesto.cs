using System;
using System.Collections;
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
        public int PuestoID { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "El Nombre debe tener entre 2 y 32 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Descripcion requerida")]
        [StringLength(128, MinimumLength = 8, ErrorMessage = "La Descripcion debe tener entre 8 y 128 caracteres")]
        public string Descripcion { get; set; }

        private string funciones;

        [Required(ErrorMessage = "Funcion/es requerida/s")]
        [MinLength(2, ErrorMessage = "Debe tener al menos 1 funcion a cargo")]
        public string Funciones
        {
            get { return PonerSaltos(funciones); }
            set { QuitarSaltos(value); }
        }
        public virtual ICollection<Empleado> Empleados { get; set; }

        [Required(ErrorMessage = "Estado requerido")]
        [DefaultValue("true")]        
        public bool Estado { get; set; }
        
        private string PonerSaltos(string cadena)
        {
            string ViejaCadena = cadena != null ? cadena : "N/A";
            string NuevaCadena =  "";

            if (ViejaCadena.Equals("N/A"))
            {
                return ViejaCadena;
            }
            else
            {
                foreach (var x in ViejaCadena)
                {
                    if (x.Equals(';')) { NuevaCadena += x + @"\n"; }
                    else { NuevaCadena += x; }
                }
                return NuevaCadena;
            }
        }

        private void QuitarSaltos(string cadena)
        {
            string NuevaCadena = "";
            bool tieneSalto = false;

            if (cadena.Equals("")) { funciones = (cadena + ";"); }
            else
            {
                if (cadena.Equals("N/A")) { funciones = (cadena + ";"); }
                else
                {
                    foreach (var x in cadena)
                    {
                        if (x.Equals(@"\n"))
                        {
                            NuevaCadena += x + ";";
                            tieneSalto = true;
                        }
                        else { NuevaCadena += x; }
                    }
                    if(tieneSalto) { funciones += (NuevaCadena + ";"); }
                    else { funciones += NuevaCadena; }
                }
            }
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