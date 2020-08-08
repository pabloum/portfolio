using AutoMapper;
using AutoMapper.Configuration;
using Portfolio.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Entities.Entities
{
    public class Experience : EntityBase
    {
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

        public decimal GetYearsExperience()
        {
            YearsExperience = (decimal)Math.Round(((DateEnd - DateBegining).Days / 365.0) * 100) / 100;
            return YearsExperience;
        }
    }
}