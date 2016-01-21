﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPV.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Contacto { get; set; }
        public string Telefono_Contacto { get; set; }
        public string Extension_Telefono_Contacto { get; set; }
        public int? Codigo { get; set; }
        public bool Estado { get; set; }
    }
}