using Portfolio.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Data.dbData
{
    public class SqlProjectDao : IRepository<Project>
    {
        private readonly PortfolioDbContext db;

        public SqlProjectDao(PortfolioDbContext db)
        {
            this.db = db;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public void Create(Project entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Project entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetAll()
        {
            throw new NotImplementedException();
        }

        public Project Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Project entity)
        {
            throw new NotImplementedException();
        }
    }
}
