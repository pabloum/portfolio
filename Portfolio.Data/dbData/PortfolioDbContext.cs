﻿using Microsoft.EntityFrameworkCore;
using Portfolio.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Data.dbData
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
        {
        }

        public DbSet<Experience> Experience { get; set; }
        public DbSet<Education> Education{ get; set; }
        public DbSet<Project> Projects{ get; set; }
        public DbSet<Skill> Skills { get; set; }
        //public DbSet<SkillType> SkillTypes { get; set; }
}
}