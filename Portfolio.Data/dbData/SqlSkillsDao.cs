using Microsoft.EntityFrameworkCore;
using Portfolio.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Data.dbData
{
    public class SqlSkillsDao : IRepository<Skill>
    {
        private readonly PortfolioDbContext db;

        public SqlSkillsDao(PortfolioDbContext db)
        {
            this.db = db;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public void Create(Skill skill)
        {
            db.Skills.Add(skill);
        }

        public void Delete(Skill skill)
        {
            if (skill != null)
            {
                db.Skills.Remove(skill);
            }
        }

        public IEnumerable<Skill> GetAll()
        {
            return db.Skills;
        }

        public Skill Read(int id)
        {
            return db.Skills.Find(id);
        }

        public void Update(Skill skill)
        {
            var entity = db.Skills.Attach(skill);
            entity.State = EntityState.Modified;
        }
    }
}
