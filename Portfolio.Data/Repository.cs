using Microsoft.EntityFrameworkCore;
using Portfolio.Data.dbData;
using Portfolio.Entities.Base;
using System;
using System.Collections.Generic;

namespace Portfolio.Data
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly DbContextOptions<PortfolioDbContext> _db;

        public Repository(DbContextOptions<PortfolioDbContext> db)
        {
            _db = db;
        }

        public IEnumerable<T> GetAll()
        {
            using (var context = new PortfolioDbContext(_db))
            {
                return context.Set<T>().ToListAsync().Result;
            }
        }

        public string Create(T entity)
        {
            using (var context = new PortfolioDbContext(_db))
            {
                context.Add(entity);
                return "Success";
            }
        }

        public T Read(int id)
        {
            using (var context = new PortfolioDbContext(_db))
            {
                var entity = context.Set<T>().SingleOrDefaultAsync(e => e.Id == id).Result;
                return entity;
            }
        }

        public string Update(int id, T entity)
        {
            using (var context = new PortfolioDbContext(_db))
            {
                context.Update(entity);
                return "Success";
            }
        }

        public string Delete(int id)
        {
            using (var context = new PortfolioDbContext(_db))
            {
                var entity = context.Set<T>().SingleOrDefaultAsync(e => e.Id == id).Result;
                context.Remove<T>(entity);
                return "Successfully deleted";
            }
        }        
    }
}
