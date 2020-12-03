using Portfolio.Entities.Entities;
using System.Collections.Generic;

namespace Portfolio.Data.InMemory
{
    public class InMemorySkillRepository : InMemoryRepository<Skill>
    {
        public InMemorySkillRepository()
        {
            var technicalSkillFactory = new TechnicalSkillFactory();
            var languageSkillFactory = new LanguageSkillFactory();
            var softSkillFactory = new SoftSkillFactory();

            Entities = new List<Skill> 
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
    }
}
