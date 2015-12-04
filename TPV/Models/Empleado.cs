using System;
using System.Collections.Generic;

namespace TPV.Models
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public char Sexo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Cedula { get; set; }

        public string Telefono { get; set; }

        public double Salario { get; set; }

        public virtual int PuestoID { get; set; }

        public virtual Puesto Puesto { get; set; }

        //public int Codigo { get; set; }

        public DateTime FechaEntrada { get; set; }

        public char Estado { get; set; }

        //No se muestran en el formulario
        public char Estatus { get; set; }

        public DateTime FechaCreacion { get; set; }

        public virtual int UsuarioID { get; set; }

        public virtual Usuario CreadoPor { get; set; } //Usuario Actual logueado
    }
}