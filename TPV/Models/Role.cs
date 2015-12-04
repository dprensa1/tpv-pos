using System;

namespace TPV.Models
{
    public class Role
    {
        public int RoleID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public char State { get; set; }

        //No se muestran en el formulario
        public char Sys_State { get; set; }

        public DateTime Sys_DateCreate { get; set; }

        public virtual int Sys_UserID { get; set; }

        public virtual User Sys_CreatedBy { get; set; }

    }
}