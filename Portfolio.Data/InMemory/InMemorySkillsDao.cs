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
            var technicalSkillFactory = new TechnicalSkillFactory();
            var languageSkillFactory = new LanguageSkillFactory();
            var softSkillFactory = new SoftSkillFactory();

            Skills = new List<Skill>
            {
                technicalSkillFactory.GetSkill("C/C++", 70),
                technicalSkillFactory.GetSkill("C#", 70),
                technicalSkillFactory.GetSkill("Ruby", 70),
                technicalSkillFactory.GetSkill(".Net Core", 70),
                technicalSkillFactory.GetSkill("Ruby on Rails", 70),

                languageSkillFactory.GetSkill("English", 90),
                languageSkillFactory.GetSkill("French", 78),
                languageSkillFactory.GetSkill("German", 60),
                languageSkillFactory.GetSkill("English", 99),

                softSkillFactory.GetSkill("Responsible", 99),
                softSkillFactory.GetSkill("Disciplined", 99),
                softSkillFactory.GetSkill("Honesty", 99),
                softSkillFactory.GetSkill("Hardworking", 99)
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
