using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPV.Models
{
    [Table("Accesos")]
    public class Rol
    {
        [Key]
        public int RolID { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "El Nombre del Rol debe tener entre 2 y 32 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Descripcion requerida")]
        [StringLength(128, MinimumLength = 8, ErrorMessage = "La Descripcion debe tener entre 8 y 128 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Acceso/s requerido/s")]
        [MinLength(1, ErrorMessage = "Debe tener al menos 1 Accesos")]
        [MaxLength(10, ErrorMessage = "Maximo 10 Accesos")]
        public virtual ICollection<Acceso> Accesos { get; set; }

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