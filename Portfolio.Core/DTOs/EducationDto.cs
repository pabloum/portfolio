using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Core.DTOs
{
    public class EducationDto
    {
        private readonly IMapper _mapper;

        public EducationDto()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EducationDto, Education>());
            _mapper = new Mapper(config);
        }

        public int Id { get; set; }
        public string University { get; set; }
        public string Title { get; set; }
        public DateTime DateBegining { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }

        public Education ToEntity()
        {
            return _mapper.Map<Education>(this);
        }
    }
}
