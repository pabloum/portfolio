﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Core.DTOs
{
    public class ExperienceDto
    {
        private readonly IMapper _mapper;

        public ExperienceDto()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ExperienceDto, Experience>());
            _mapper = new Mapper(config);
        }

        public int Id { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string MainFunctions { get; set; }
        public string Technologies { get; set; }
        public DateTime DateBegining { get; set; }
        public DateTime DateEnd { get; set; }
        public decimal YearsExperience { get; set; }

        public Experience ToEntity()
        {
            return _mapper.Map<Experience>(this);
        }
    }
}
