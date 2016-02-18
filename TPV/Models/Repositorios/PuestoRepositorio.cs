using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPV.Models.Repositorios
{
    public class PuestoRepositorio : IRepositorio<Puesto>
    {
        LyraContext _PuestoContext = new LyraContext();

        public IEnumerable<Puesto> List
        {
            get
            {
                return _PuestoContext.Puestos.ToList();
            }
        }

        public void Add(Puesto entity)
        {
            _PuestoContext.Puestos.Add(entity);
            _PuestoContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            _PuestoContext.Puestos.Remove(
                FindById(Id)
                );
            _PuestoContext.SaveChanges();
        }

        public Puesto FindById(int Id)
        {
            return (from a in List where a.PuestoID == Id select a).FirstOrDefault();
            
        }

        public Puesto Find(Puesto entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Puesto entity)
        {
            _PuestoContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _PuestoContext.SaveChanges();
        }
    }
}