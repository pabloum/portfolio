using Microsoft.EntityFrameworkCore;
using Portfolio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Create(Experience experience)
        {
            db.Experience.Add(experience);
        }

        public void Delete(Experience experience)
        {
            if (experience != null)
            {
                db.Experience.Remove(experience);
            }
        }

        public IEnumerable<Experience> GetAll()
        {
            return db.Experience;
        }

        public Experience Read(int id)
        {
            //var experience = db.Experience.Where(r => r.Id == id).SingleOrDefault();
            var experience =  db.Experience.Find(id);
            return experience;
        }

        public void Update(Experience experience)
        {
            var entity = db.Experience.Attach(experience);
            entity.State = EntityState.Modified;
        }
    }
}
