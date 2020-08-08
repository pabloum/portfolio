using AutoMapper;
using Portfolio.Entities.DTOs;
using Portfolio.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Entities
{
    public class EntitiesProfiler : Profile
    {
        public EntitiesProfiler()
        {
            CreateMap<Experience, ExperienceDto>().ReverseMap();
            CreateMap<Education, EducationDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Skill, SkillDto>().ReverseMap();
        }
    }
}
