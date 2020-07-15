using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Core.DTOs
{
    public class ProjectDto
    {
        private readonly IMapper _mapper;

        public ProjectDto()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProjectDto, Project>());
            _mapper = new Mapper(config);
        }

        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Technologies { get; set; }
        public string Description { get; set; }

        public Project ToEntity()
        {
            return _mapper.Map<Project>(this);
        }
    }
}
