using System;
using System.Collections.Generic;
using System.Linq;

namespace TPV.Models.Repositories
{
    public class UsuarioRepositorio : IRepositorio<Usuario>
    {
        LyraContext _UsuarioContext = new LyraContext();

        public IEnumerable<Usuario> List
        {
            get
            {
                return _UsuarioContext.Usuarios.ToList();
            }
        }

        public void Add(Usuario entity)
        {
            _UsuarioContext.Usuarios.Add(entity);
            _UsuarioContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            _UsuarioContext.Usuarios.Remove(
                FindById(Id)
                );
            _UsuarioContext.SaveChanges();
        }

        public Usuario FindById(int Id)
        {
            return (from a in List where a.UsuarioID == Id select a).FirstOrDefault();
        }

        public Usuario Find(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario entity)
        {
            _UsuarioContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _UsuarioContext.SaveChanges();
        }
    }
}