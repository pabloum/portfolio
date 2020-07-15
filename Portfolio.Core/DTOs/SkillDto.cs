using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Core.DTOs
{
    public class SkillDto
    {
        private readonly IMapper _mapper;

        public SkillDto()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SkillDto, Skill>());
            _mapper = new Mapper(config);
        }

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
