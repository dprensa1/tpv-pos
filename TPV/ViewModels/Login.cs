using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPV.ViewModels
{
    [NotMapped]
    public class Login
    {
        [Required(ErrorMessage = "Nombre requerido", AllowEmptyStrings = false)]
        [Index("UserIDX", IsUnique = true)]
        [StringLength(10, MinimumLength = 4, ErrorMessage = " El usuario deber tener entre 4 y 10 caracteres")]
        public string User { get; set; }

        [Required(ErrorMessage = "Contraseña obligatoria", AllowEmptyStrings = false)]
        [StringLength(16, MinimumLength = 4, ErrorMessage = " La contraseña deber tener entre 6 y 16 caracteres")]
        public string Clave { get; set; }
    }
}