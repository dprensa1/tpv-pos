namespace TPV.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Contacto { get; set; }
        public string Telefono_Contacto { get; set; }
        public int Codigo { get; set; }
        public bool Estado { get; set; }
        public string CreadoEn { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoEn { get; set; }
        public string ModificadoPor { get; set; }



        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int? ClienteID { get; set; }
        //public string Nombre { get; set; }
        //public string Apellido { get; set; }
        //public string Identificacion { get; set; }
        //public string Telefono { get; set; }
        //public string Contacto { get; set; }
        //public string Telefono_Contacto { get; set; }
        //public int? Codigo { get; set; }
        //public bool Estado { get; set; }
    }
}