using Portfolio.Core;
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

            };
        }

        public void Create(Skill skill)
        {
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
                // TODO Update all. I'm not sure if this solution works
                result = skill;
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
