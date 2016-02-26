using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPV.Models
{
    [Table("Usuarios")]
    public class Usuario //: IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? UsuarioID { get; set; }

        public int? EmpleadoID { get; set; }
        public virtual Empleado Empleado { get; set; }

        private string _User { get; set; }

        [Required(ErrorMessage = "Nombre requerido", AllowEmptyStrings = false)]
        [Index("UserIDX", IsUnique = true)]
        [StringLength(10, MinimumLength = 4, ErrorMessage = " El usuario deber tener entre 4 y 10 caracteres")]
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }

        [Required(ErrorMessage = "Contraseña obligatoria", AllowEmptyStrings = false)]
        [StringLength(16, MinimumLength = 4, ErrorMessage = " La contraseña deber tener entre 6 y 16 caracteres")]
        public string Clave { get; set; }

        public int RolID { get; set; }

        [ForeignKey("RolID")]
        public virtual ICollection<Rol> Rols { get; set; }

        [DefaultValue("1")]
        public bool Estado { get; set; }

        public string CreadoEn { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoEn { get; set; }
        public string ModificadoPor { get; set; }
    }
}