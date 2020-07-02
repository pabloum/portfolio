using Portfolio.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Data.dbData
{
    public class SqlEducationDao : IRepository<Education>
    {
        private readonly PortfolioDbContext db;

        public SqlEducationDao(PortfolioDbContext db)
        {
            this.db = db;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public void Create(Education entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Education entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Education> GetAll()
        {
            throw new NotImplementedException();
        }

        public Education Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Education entity)
        {
            throw new NotImplementedException();
        }
    }
}
