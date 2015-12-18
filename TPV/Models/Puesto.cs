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
        public int PuestoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Funciones
        {
            get { return Funciones; }
            set { Funciones += ";" + value.ToString(); }
        }
        public virtual ICollection<Empleado> Empleados { get; set; }
        [DefaultValue("true")]
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