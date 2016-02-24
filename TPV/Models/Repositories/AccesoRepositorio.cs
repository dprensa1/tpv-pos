using System;
using System.Collections.Generic;
using System.Linq;

namespace TPV.Models.Repositories
{
    public class AccesoRepositorio : IRepositorio<Acceso>
    {
        LyraContext _Context = new LyraContext();

        public IEnumerable<Acceso> List
        {
            get
            {
                return _Context.Accesos.ToList();
            }
        }

        public void Add(Acceso entity)
        {
            _Context.Accesos.Add(entity);
            _Context.SaveChanges();
        }

        public void Delete(int Id)
        {
            _Context.Accesos.Remove(
                FindById(Id)
                );
            _Context.SaveChanges();
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
            _Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _Context.SaveChanges();
        }
    }
}