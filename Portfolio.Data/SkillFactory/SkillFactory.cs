using Portfolio.Entities;
using Portfolio.Entities.Entities;

namespace Portfolio.Data
{
    public abstract class SkillFactory
    {
        protected static int IdCounter = 0;

        protected abstract Skill CreateSkill(string name, int percentage);

        public Skill GetSkill(string name, int percentage)
        {
            var skill = CreateSkill(name, percentage);
            return skill;
        }
    }

    public class TechnicalSkillFactory : SkillFactory
    {
        protected override Skill CreateSkill(string name, int percentage)
        {
            return new Skill { Id = ++IdCounter, Name = name, Percentage = percentage, Category = SkillType.Technical };
        }
    }

    public class LanguageSkillFactory : SkillFactory
    {
        protected override Skill CreateSkill(string name, int percentage)
        {
            return new Skill { Id = ++IdCounter, Name = name, Percentage = percentage, Category = SkillType.Language };
        }
    }

    public class SoftSkillFactory : SkillFactory
    {
        protected override Skill CreateSkill(string name, int percentage)
        {
            return new Skill { Id = ++IdCounter, Name = name, Percentage = percentage, Category = SkillType.Soft };
        }
    }
}
