using Portfolio.Entities;
using Portfolio.Entities.Entities;

namespace Portfolio.Data
{
    public static class SkillFactory
    {
        private static int IdCounter = 0;

        public static Skill CreateSkill(string name, int percentage, SkillType type)
        {
            return new Skill { Id = ++IdCounter, Name = name, Percentage = percentage, Category = type };
        }
    }
}
