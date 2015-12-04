using System;

namespace TPV.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public char Sex { get; set; }

        //Date of Birth
        public DateTime Dob { get; set; }

        public string Identification { get; set; }

        public string Phone { get; set; }

        public double LastSalary { get; set; }

        public double Salary { get; set; }

        public int PositionID { get; set; }

        public virtual Position Position { get; set; }

        public int Code { get; set; }

        public DateTime EntranceDate { get; set; }

        public char State { get; set; }

        //************No se muestran en el formulario************\\
        //Para Eliminar. Posible Backup
        public char Sys_State { get; set; }

        public DateTime Sys_DateCreate { get; set; }

        public virtual int Sys_UserID { get; set; }

        public virtual User Sys_CreatedBy { get; set; }
    }
}