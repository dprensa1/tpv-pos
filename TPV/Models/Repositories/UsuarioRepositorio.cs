using System;
using System.Collections.Generic;
using System.Linq;

namespace TPV.Models.Repositories
{
    public class UsuarioRepositorio : IRepositorio<Usuario>
    {
        LyraContext _Context = new LyraContext();

        public IEnumerable<Usuario> List
        {
            get
            {
                return _Context.Usuarios.ToList();
            }
        }

        public void Add(Usuario entity)
        {
            _Context.Usuarios.Add(entity);
            _Context.SaveChanges();
        }

        public void Delete(int Id)
        {
            _Context.Usuarios.Remove(
                FindById(Id)
                );
            _Context.SaveChanges();
        }

        public Usuario FindById(int Id)
        {
            return (from a in List where a.UsuarioID == Id select a).FirstOrDefault();
        }

        public Usuario FindByUserName(string username)
        {
            return (from a in List where a.User == username select a).FirstOrDefault();
        }

        public void Update(Usuario entity)
        {
            _Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _Context.SaveChanges();
        }

        public string [] UserInRoles(string username)
        {
            return (
                from r in _Context.Roles
                join u in _Context.Usuarios
                    on r.RolID equals u.RolID
                where u.User.Equals(username)
                select r.Nombre).ToArray();
        }
    }
}