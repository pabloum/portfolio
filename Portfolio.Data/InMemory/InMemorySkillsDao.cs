using Portfolio.Data.Utility;
using Portfolio.Entities;
using Portfolio.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Data.InMemory
{
    public class InMemorySkillsDao : IDao<Skill>
    {
        private List<Skill> Skills { get; set; }

        public InMemorySkillsDao()
        {
            Skills = new List<Skill>
            {
                new Skill { Id = 1, Name = "C/C++",         Percentage = 70, Category = SkillType.Technical },
                new Skill { Id = 2, Name = "C#",            Percentage = 70, Category = SkillType.Technical },
                new Skill { Id = 3, Name = "Ruby",          Percentage = 70, Category = SkillType.Technical },
                new Skill { Id = 4, Name = ".Net Core",     Percentage = 70, Category = SkillType.Technical },
                new Skill { Id = 5, Name = "Ruby on Rails", Percentage = 50, Category = SkillType.Technical },
                new Skill { Id = 6, Name = "English",       Percentage = 90, Category = SkillType.Language },
                new Skill { Id = 7, Name = "French",        Percentage = 78, Category = SkillType.Language },
                new Skill { Id = 8, Name = "German",        Percentage = 60, Category = SkillType.Language },
                new Skill { Id = 9, Name = "Spanish",       Percentage = 99, Category = SkillType.Language },
                new Skill { Id = 10, Name = "Responsible",  Percentage = 99, Category = SkillType.Soft },
                new Skill { Id = 11, Name = "Disciplined",  Percentage = 99, Category = SkillType.Soft },
            };
        }

        public Skill Create(Skill skill)
        {
            skill.Id = Skills.Max(s => s.Id) + 1;
            Skills.Add(skill);
            return skill;
        }

        public Skill Read(int id)
        {
            return Skills.Where(s => s.Id == id).FirstOrDefault();
        }

        public Skill Update(Skill skill)
        {
            var result = Skills.Where(s => s.Id == skill.Id).FirstOrDefault();

            if (result != null)
            {
                Skills.ReplaceWith(result, skill);
            }

            return result;
        }

        public void Delete(Skill skill)
        {
            Skills.Remove(skill);
        }

        public IEnumerable<Skill> GetAll()
        {
            return Skills;
        }

        public int Commit()
        {
            return 0;
        }
    }
}
