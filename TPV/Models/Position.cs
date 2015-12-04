using System;

namespace TPV.Models
{
    public class Position
    {
        public int PositionID { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public char State { get; set; }

        //No se muestran en el formulario
        public char Sys_State { get; set; }

        public DateTime Sys_DateCreate { get; set; }

        public virtual int Sys_UserID { get; set; }

        public virtual User Sys_CreatedBy { get; set; }
    }
}