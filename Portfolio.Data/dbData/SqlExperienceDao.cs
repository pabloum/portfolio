using Portfolio.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Data.dbData
{
    public class SqlExperienceDao : IRepository<Experience>
    {
        private readonly PortfolioDbContext db;

        public SqlExperienceDao(PortfolioDbContext db)
        {
            this.db = db;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public void Create(Experience entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Experience entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Experience> GetAll()
        {
            throw new NotImplementedException();
        }

        public Experience Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Experience entity)
        {
            throw new NotImplementedException();
        }
    }
}
