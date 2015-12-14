using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPV.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        public int EmpleadoID { get; set; }

        [ForeignKey("Puesto_FK")]
        public virtual Empleado Empleado { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(10, MinimumLength =3, ErrorMessage = "El Nombre de Usuario debe tener entre 6 y 10 caracteres")]
        [Display(Name = "Usuario")]
        [Index(IsUnique = true)]
        public string User { get; set; }

        [Required(ErrorMessage = "Contraseña obligatoria")]
        [DataType(DataType.Password)]
        [Display(Name = "Clave/Contraseña")]
        public string Clave { get; set; }

        [ForeignKey("RolUsuario_FK")]
        public virtual ICollection<Rol> Rol { get; set; }

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