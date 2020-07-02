using Microsoft.EntityFrameworkCore;
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

        public void Create(Education education)
        {
            db.Education.Add(education);
        }

        public void Delete(Education education)
        {
            if (education != null)
            {
                db.Education.Remove(education);
            }
        }

        public IEnumerable<Education> GetAll()
        {
            return db.Education;
        }

        public Education Read(int id)
        {
            return db.Education.Find(id);
        }

        public void Update(Education education)
        {
            var entity = db.Education.Attach(education);
            entity.State = EntityState.Modified;
        }
    }
}
