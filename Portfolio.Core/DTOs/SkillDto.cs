using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Core.DTOs
{
    public class SkillDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SkillType Category { get; set; }
        public int Percentage { get; set; }

        public Skill ToEntity()
        {
            return new Skill
            {
                Id = this.Id,
                Name = this.Name,
                Category = this.Category,
                Percentage = this.Percentage
            };
        }
    }
}
