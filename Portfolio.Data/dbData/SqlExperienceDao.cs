using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Data.dbData
{
    public class SqlExperienceDao : IRepository<Experience>, IDisposable
    {
        private readonly DbContextOptions<PortfolioDbContext> _db;

        public SqlExperienceDao(DbContextOptions<PortfolioDbContext> dbContext)
        {
            _db = dbContext;
        }

        public int Commit() // OJO
        {
            using (var context = new PortfolioDbContext(_db))
            {
                return context.SaveChanges();
            }
        }

        public void Create(Experience experience)
        {
            using (var context = new PortfolioDbContext(_db) )
            {
                experience.Id = context.Experience.Max(e => e.Id) + 1;
                context.Experience.Add(experience);
                context.SaveChanges();
            }
        }

        public void Delete(Experience experience)
        {
            if (experience != null)
            {
                using (var context = new PortfolioDbContext(_db))
                {
                    context.Experience.Remove(experience);
                    context.SaveChanges();
                }
            }
        }

        public void Dispose()
        {
            using (var context = new PortfolioDbContext(_db))
            {
                context.Dispose();
            }
        }

        public IEnumerable<Experience> GetAll()
        {
            using (var context = new PortfolioDbContext(_db))
            {
                return context.Experience.AsNoTracking().ToList();
            }
        }

        public Experience Read(int id)
        {
            using (var context = new PortfolioDbContext(_db))
            {
                var experience =  context.Experience.AsNoTracking().SingleOrDefault(e => e.Id == id); //WITH NO LOCK
                return experience;
            }
        }

        public void Update(Experience experience)
        {
            using (var context = new PortfolioDbContext(_db))
            {
                var entity = context.Experience.Attach(experience);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
