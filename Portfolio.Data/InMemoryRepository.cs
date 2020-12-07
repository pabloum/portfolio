using Portfolio.Data.Utility;
using Portfolio.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Portfolio.Data
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected virtual List<T> Entities { get; set; }
        public InMemoryRepository()
        {
        }

        public IEnumerable<T> GetAll()
        {
            return Entities;
        }

        public string Create(T entity)
        {
            Entities.Add(entity);
            return "Success";
        }

        public T Read(int id)
        {
            return Entities.SingleOrDefault(e => e.Id == id);
        }

        public string Update(int id, T entity)
        {
            var record = Entities.SingleOrDefault(r => r.Id == entity.Id);

            if (record != null)
            {
                Entities.ReplaceWith(record, entity);
            }

            return "Success";
        }

        public string Delete(int id)
        {
            var entity = Entities.SingleOrDefault(e => e.Id == id);
            Entities.Remove(entity);
            return "Succesfully deleted";
        }
    }
}
