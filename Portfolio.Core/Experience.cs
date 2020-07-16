﻿using AutoMapper;
using AutoMapper.Configuration;
using Portfolio.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Core
{
    public class Experience
    {
        private readonly IMapper _mapper;

        public Experience()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Experience, ExperienceDto>());
            _mapper = new Mapper(config);
        }

        public decimal GetYearsExperience()
        {
            YearsExperience = (decimal)Math.Round(((DateEnd - DateBegining).Days / 365.0) * 100) / 100;
            return YearsExperience;
        }

        public int Id { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string MainFunctions { get; set; }
        public string Technologies { get; set; }
        public DateTime DateBegining { get; set; }
        public DateTime DateEnd { get; set; }
        public decimal YearsExperience { get; set; }

        public ExperienceDto ToDto()
        {
            return _mapper.Map<ExperienceDto>(this);
        }
    }
}