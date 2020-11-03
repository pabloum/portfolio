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
                SkillFactory.CreateSkill("C/C++",         70, SkillType.Technical),
                SkillFactory.CreateSkill("C#",            70, SkillType.Technical),
                SkillFactory.CreateSkill("Ruby",          70, SkillType.Technical),
                SkillFactory.CreateSkill(".Net Core",     70, SkillType.Technical),
                SkillFactory.CreateSkill("Ruby on Rails", 70, SkillType.Technical),

                SkillFactory.CreateSkill("English", 90, SkillType.Language),
                SkillFactory.CreateSkill("French",  78, SkillType.Language),
                SkillFactory.CreateSkill("German",  60, SkillType.Language),
                SkillFactory.CreateSkill("Spanish", 99, SkillType.Language),

                SkillFactory.CreateSkill("Responsible", 99, SkillType.Soft),
                SkillFactory.CreateSkill("Disciplined", 99, SkillType.Soft)
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
