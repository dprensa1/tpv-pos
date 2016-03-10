using System;
using System.Collections.Generic;
using System.Linq;

namespace TPV.Models.Repositories
{
    public class RolRepositorio : IRepositorio<Rol>
    {
        LyraContext _RolContext = new LyraContext();

        public IEnumerable<Rol> List
        {
            get
            {
                //return _RolContext.Roles.ToList();
                throw new NotImplementedException();
            }
        }

        public void Add(Rol entity)
        {
            _RolContext.Roles.Add(entity);
            _RolContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            _RolContext.Roles.Remove(
                FindById(Id)
                );

            _RolContext.SaveChanges();
        }

        public Rol FindById(int Id)
        {
            return (from a in List where a.RolId == Id select a).FirstOrDefault();
        }

        public Rol Find(Rol entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Rol entity)
        {
            _RolContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _RolContext.SaveChanges();
        }
    }
}