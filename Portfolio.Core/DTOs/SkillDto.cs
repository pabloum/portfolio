using Portfolio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Core.DTOs
{
    public class SkillDto : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SkillType Category { get; set; }
        public int Percentage { get; set; }

        public Skill ToEntity()
        {
            return _mapper.Map<Skill>(this);
        }
    }
}
