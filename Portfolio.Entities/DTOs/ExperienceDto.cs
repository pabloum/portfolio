using AutoMapper;
using Portfolio.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Entities.DTOs
{
    public class ExperienceDto : EntityBase
    {
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
