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

        public void Create(Skill entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Skill entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skill> GetAll()
        {
            throw new NotImplementedException();
        }

        public Skill Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Skill entity)
        {
            throw new NotImplementedException();
        }
    }
}
