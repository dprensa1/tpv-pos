using System;
using System.Collections.Generic;

namespace TPV.Models
{
    public class User
    {
        public int UserID { get; set; }

        public int EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }

        public string UserName { get; set; }

        public string Pass { get; set; }

        public virtual ICollection<Rol> Rol { get; set; }

        public char State { get; set; }

        //No se muestran en el formulario
        public char Sys_State { get; set; }

        public DateTime Sys_DateCreate { get; set; }

        public int Sys_UserID { get; set; }
    }
}