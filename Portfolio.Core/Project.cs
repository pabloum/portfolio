using AutoMapper;
using Portfolio.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Core
{
    public class Project
    {
        private readonly IMapper _mapper;

        public Project()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Project, ProjectDto>());
            _mapper = new Mapper(config);
        }

        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Technologies { get; set; }
        public string Description { get; set; }

        public ProjectDto ToDto()
        {
            return _mapper.Map<ProjectDto>(this);
        }
    }
}
