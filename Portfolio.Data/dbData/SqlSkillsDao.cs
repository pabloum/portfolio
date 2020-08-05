using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Data.dbData
{
    public class SqlSkillsDao : IRepository<Skill>
    {
        private readonly DbContextOptions<PortfolioDbContext> _db;

        public SqlSkillsDao(DbContextOptions<PortfolioDbContext> db)
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

        public void Create(Skill skill)
        {
            using (var context = new PortfolioDbContext(_db))
            {
                skill.Id = context.Skills.Max(s => s.Id) + 1;
                context.Skills.Add(skill);
                context.SaveChanges();
            }
        }

        public void Delete(Skill skill)
        {
            if (skill != null)
            {
                using (var context = new PortfolioDbContext(_db))
                {
                    context.Skills.Remove(skill);
                    context.SaveChanges();
                }
            }
        }

        public IEnumerable<Skill> GetAll()
        {
            using (var context = new PortfolioDbContext(_db))
            {
                return context.Skills.AsNoTracking().ToList();
            }
        }

        public Skill Read(int id)
        {
            using (var context = new PortfolioDbContext(_db))
            {
                return context.Skills.AsNoTracking().SingleOrDefault(e => e.Id == id);
            }
        }

        public void Update(Skill skill)
        {
            using (var context = new PortfolioDbContext(_db))
            {
                var entity = context.Skills.Attach(skill);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
