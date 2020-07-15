using Microsoft.EntityFrameworkCore;
using Portfolio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Data.dbData
{
    public class SqlEducationDao : IRepository<Education>
    {
        private readonly DbContextOptions<PortfolioDbContext> _db;

        public SqlEducationDao(DbContextOptions<PortfolioDbContext> db)
        {
            _db = db;
        }

        public int Commit()
        {
            using (var context = new PortfolioDbContext(_db))
            {
                return context.SaveChanges();
            }
        }

        public void Create(Education education)
        {
            using (var context = new PortfolioDbContext(_db))
            {
                education.Id = context.Education.Max(e => e.Id) + 1;
                context.Education.Add(education);
                context.SaveChanges();
            }
        }

        public void Delete(Education education)
        {
            if (education != null)
            {
                using (var context = new PortfolioDbContext(_db))
                {
                    context.Education.Remove(education);
                    context.SaveChanges();
                }
            }
        }

        public IEnumerable<Education> GetAll()
        {
            using (var context = new PortfolioDbContext(_db))
            {
                return context.Education.ToList();
            }
        }

        public Education Read(int id)
        {
            using (var context = new PortfolioDbContext(_db))
            {
                return context.Education.AsNoTracking().SingleOrDefault(e => e.Id == id);
            }
        }

        public void Update(Education education)
        {
            using (var context = new PortfolioDbContext(_db))
            {
                var entity = context.Education.Attach(education);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
