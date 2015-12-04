using System;

namespace TPV.Models
{
    public class Client
    {        
        public int ID { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        //Cedula, RNC, Pasaporte, etc.
        public string Identification { get; set; }

        public string Phone { get; set; }

        //Persona a la cual contactar
        public string ContactPerson { get; set; }

        public string PhoneContactPerson { get; set; }

        public string ContactPhoneExtension { get; set; }

        //Codigo del Cliente
        public int Code { get; set; }

        //Activo o Desactivado
        public char State { get; set; }

        //No se muestran en el formulario
        public char Sys_State { get; set; }

        public DateTime Sys_DateCreate { get; set; }

        public int UserID { get; set; }

        public virtual User Sys_CreatedBy { get; set; }

    }
}