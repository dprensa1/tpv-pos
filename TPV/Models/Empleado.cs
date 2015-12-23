using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPV.Models
{
    [Table("Empleados")]
    public class Empleado
    {
        [Key]
        public int EmpleadoID { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public char Sexo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FechaNacimiento { get; set; }

        public string Cedula { get; set; }

        public string Telefono { get; set; }

        public double Salario { get; set; }

        public int PuestoID { get; set; }

        [ForeignKey("PuestoID")]
        public virtual ICollection<Puesto> Puesto { get; set; }

        [DefaultValue("00000")]
        public int Codigo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FechaEntrada { get; set; }

        [DefaultValue("1")]
        public bool Activo { get; set; }

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