using System;
using System.Collections.Generic;
using System.Linq;

namespace TPV.Models.Repositories
{
    public class ClienteRepositorio : IRepositorio<Cliente>
    {
        LyraContext _ClienteContext = new LyraContext();

        public IEnumerable<Cliente> List
        {
            get
            {
                return _ClienteContext.Clientes.ToList();
            }
        }

        public void Add(Cliente entity)
        {
            _ClienteContext.Clientes.Add(entity);
            _ClienteContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            _ClienteContext.Clientes.Remove(
                FindById(Id)
                );
            _ClienteContext.SaveChanges();
        }

        public Cliente FindById(int Id)
        {
            return (from a in List where a.ClienteId == Id select a).FirstOrDefault();
        }

        public Cliente Find(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente entity)
        {
            _ClienteContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _ClienteContext.SaveChanges();
        }
    }
}