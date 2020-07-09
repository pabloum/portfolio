using Portfolio.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Core
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SkillType Category { get; set; }
        public int Percentage { get; set; }

        public SkillDto ToDto()
        {
            return new SkillDto { 
                Id         = this.Id,
                Name       = this.Name,
                Category   = this.Category,
                Percentage = this.Percentage
            };
        }
    }
}
