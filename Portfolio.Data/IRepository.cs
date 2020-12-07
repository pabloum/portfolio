using Portfolio.Entities.Base;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        string Create(T entity);
        T Read(int id);
        string Update(int id, T entity);
        string Delete(int id);
    }
}
