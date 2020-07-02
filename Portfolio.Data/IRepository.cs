using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Data
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Create(T entity);
        T Read(int id);
        void Update(T entity);
        void Delete(T entity);
        int Commit();
    }
}
