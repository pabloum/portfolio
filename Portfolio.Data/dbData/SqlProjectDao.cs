using Microsoft.EntityFrameworkCore;
using Portfolio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Data.dbData
{
    public class SqlProjectDao : IRepository<Project>
    {
        private readonly DbContextOptions<PortfolioDbContext> _db;

        public SqlProjectDao(DbContextOptions<PortfolioDbContext> db)
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

        public void Create(Project project)
        {
            using (var context = new PortfolioDbContext(_db))
            {
                project.Id = context.Projects.Max(p => p.Id) + 1;
                context.Projects.Add(project);
                context.SaveChanges();
            }
        }

        public void Delete(Project project)
        {
            if (project != null)
            {
                using (var context = new PortfolioDbContext(_db))
                {
                    context.Projects.Remove(project);
                    context.SaveChanges();
                }
            }
        }

        public IEnumerable<Project> GetAll()
        {
            using (var context = new PortfolioDbContext(_db))
            {
                return context.Projects.ToList();
            }
        }

        public Project Read(int id)
        {
            using (var context = new PortfolioDbContext(_db))
            {
                return context.Projects.Find(id);
            }
        }

        public void Update(Project project)
        {
            using (var context = new PortfolioDbContext(_db))
            {
                var entity = context.Projects.Attach(project);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
