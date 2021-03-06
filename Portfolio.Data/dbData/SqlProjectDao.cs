﻿using Microsoft.EntityFrameworkCore;
using Portfolio.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Data.dbData
{
    public class SqlProjectDao : IDao<Project>
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

        public Project Create(Project project)
        {
            using (var context = new PortfolioDbContext(_db))
            {
                project.Id = context.Projects.Max(p => p.Id) + 1;
                context.Projects.Add(project);
                context.SaveChanges();
                return project;
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
                return context.Projects.AsNoTracking().ToList();
            }
        }

        public Project Read(int id)
        {
            using (var context = new PortfolioDbContext(_db))
            {
                return context.Projects.AsNoTracking().SingleOrDefault(e => e.Id == id);
            }
        }

        public Project Update(Project project)
        {
            using (var context = new PortfolioDbContext(_db))
            {
                var entity = context.Projects.Attach(project);
                entity.State = EntityState.Modified;
                context.SaveChanges();
                return entity.Entity;
            }
        }
    }
}
