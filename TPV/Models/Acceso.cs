using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPV.Models
{
    [Table("Accesos")]
    public class Acceso
    {
        [Key]
        public int AccesoID { get; set; }
        public string Nombre { get; set; }
        public string Rutas
        {
            get { return Rutas; }
            set { Rutas += ";" + value.ToString(); }
        }
        public virtual ICollection<Rol> Roles { get; set; }

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