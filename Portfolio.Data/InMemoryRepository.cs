using Portfolio.Entities.Base;
using System;
using System.Collections.Generic;

namespace Portfolio.Data
{
    public class InMemoryRepository<T> : IRepository<T> where T : EntityBase
    {
        public InMemoryRepository()
        {

        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public string Create(T entity)
        {
            throw new NotImplementedException();
        }

        public T Read(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(int id, T entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
