using AutoMapper;
using Portfolio.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Core
{
    public class Skill
    {
        private readonly IMapper _mapper;

        public Skill()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Skill, SkillDto>());
            _mapper = new Mapper(config);
        }

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
