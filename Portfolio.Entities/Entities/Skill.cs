using AutoMapper;
using Portfolio.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Entities.Entities
{
    public class Skill : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SkillType Category { get; set; }
        public int Percentage { get; set; }

        public SkillDto ToDto()
        {
            return _mapper.Map<SkillDto>(this);
        }
    }
}
