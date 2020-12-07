using Portfolio.Data;
using Portfolio.Entities.Base;
using System.Collections.Generic;

namespace Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public string Create(T entity)
        {
            return _repository.Create(entity);
        }

        public T Read(int id)
        {
            return _repository.Read(id);
        }

        public string Update(int id, T entity)
        {
            return _repository.Update(id, entity);
        }

        public string Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
