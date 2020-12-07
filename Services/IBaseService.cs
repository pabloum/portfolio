using Portfolio.Entities.Base;
using System.Collections.Generic;

namespace Services
{
    public interface IBaseService<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        string Create(T entity);
        T Read(int id);
        string Update(int id, T entity);
        string Delete(int id);
    }
}
