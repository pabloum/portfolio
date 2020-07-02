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
        private readonly PortfolioDbContext db;

        public SqlProjectDao(PortfolioDbContext db)
        {
            this.db = db;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public void Create(Project project)
        {
            project.Id = db.Projects.Max(p => p.Id) + 1;
            db.Projects.Add(project);
        }

        public void Delete(Project project)
        {
            if (project != null)
            {
                db.Projects.Remove(project);
            }
        }

        public IEnumerable<Project> GetAll()
        {
            return db.Projects;
        }

        public Project Read(int id)
        {
            return db.Projects.Find(id);
        }

        public void Update(Project project)
        {
            var entity = db.Projects.Attach(project);
            entity.State = EntityState.Modified;
        }
    }
}
