using System;
using System.Collections.Generic;
using System.Linq;

namespace TPV.Models.Repositories
{
    public class AccesoRepositorio : IRepositorio<Acceso>
    {
        LyraContext _AccesoContext = new LyraContext();

        public IEnumerable<Acceso> List
        {
            get
            {
                return _AccesoContext.Accesos.ToList();
            }
        }

        public void Add(Acceso entity)
        {
            _AccesoContext.Accesos.Add(entity);
            _AccesoContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            _AccesoContext.Accesos.Remove(
                FindById(Id)
                );
            _AccesoContext.SaveChanges();
        }

        public Acceso FindById(int Id)
        {
            return (from a in List where a.AccesoID == Id select a).FirstOrDefault();
        }

        public Acceso Find(Acceso entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Acceso entity)
        {
            _AccesoContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _AccesoContext.SaveChanges();
        }
    }
}