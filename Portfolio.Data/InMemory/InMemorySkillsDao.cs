﻿using Portfolio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Data.InMemory
{
    public class InMemorySkillsDao : IRepository<Skill>
    {
        private List<Skill> Skills { get; set; }

        public InMemorySkillsDao()
        {
            Skills = new List<Skill>
            {
                new Skill { Id = 1, Name = "C/C++",         Percentage = 70, Category = "Programming languages" },
                new Skill { Id = 2, Name = "C#",            Percentage = 70, Category = "Programming languages" },
                new Skill { Id = 3, Name = "Ruby",          Percentage = 70, Category = "Programming languages" },
                new Skill { Id = 4, Name = ".Net Core",     Percentage = 70, Category = "Web Framework" },
                new Skill { Id = 5, Name = "Ruby on Rails", Percentage = 50, Category = "Web Framework" },
                new Skill { Id = 6, Name = "English",       Percentage = 90, Category = "Language" },
                new Skill { Id = 7, Name = "French",        Percentage = 78, Category = "Language" },
                new Skill { Id = 8, Name = "German",        Percentage = 60, Category = "Language" },
                new Skill { Id = 9, Name = "Spanish",       Percentage = 99, Category = "Language" }
            };
        }

        public void Create(Skill skill)
        {
            skill.Id = Skills.Max(s => s.Id) + 1;
            Skills.Add(skill);
        }

        public Skill Read(int id)
        {
            return Skills.Where(s => s.Id == id).FirstOrDefault();
        }

        public void Update(Skill skill)
        {
            var result = Skills.Where(s => s.Id == skill.Id).FirstOrDefault();

            if (result != null)
            {
                result.Name = skill.Name;
                result.Percentage = skill.Percentage;
                result.Category = skill.Category;
            }
        }

        public void Delete(Skill skill)
        {
            Skills.Remove(skill);
        }

        public IEnumerable<Skill> GetAll()
        {
            return Skills;
        }
    }
}