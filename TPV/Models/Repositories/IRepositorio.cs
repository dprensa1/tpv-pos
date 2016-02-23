using System.Collections.Generic;

namespace TPV.Models.Repositories
{
    public interface IRepositorio<T>
    {
        IEnumerable<T> List { get; }
        void Add(T entity);
        void Delete(int Id);
        void Update(T entity);
        T FindById(int Id);
        T Find(T entity);
    }
}