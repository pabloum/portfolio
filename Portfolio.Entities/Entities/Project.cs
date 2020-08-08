using AutoMapper;
using Portfolio.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Entities.Entities
{
    public class Project : EntityBase
    {
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
