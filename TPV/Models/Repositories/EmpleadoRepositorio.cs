using System;
using System.Collections.Generic;
using System.Linq;

namespace TPV.Models.Repositories
{
    public class EmpleadoRepositorio : IRepositorio<Empleado>
    {
        LyraContext _EmpleadoContext = new LyraContext();

        public IEnumerable<Empleado> List
        {
            get
            {
                return _EmpleadoContext.Empleados.ToList();
            }
        }

        public void Add(Empleado entity)
        {
            _EmpleadoContext.Empleados.Add(entity);
            _EmpleadoContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            _EmpleadoContext.Empleados.Remove(
                FindById(Id)
                );
            _EmpleadoContext.SaveChanges();
        }

        public Empleado FindById(int Id)
        {
            return (from a in List where a.EmpleadoID == Id select a).FirstOrDefault();
        }

        public Empleado Find(Empleado entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Empleado entity)
        {
            _EmpleadoContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _EmpleadoContext.SaveChanges();
        }
    }
}