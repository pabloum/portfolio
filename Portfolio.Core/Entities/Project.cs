using AutoMapper;
using Portfolio.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Core.Entities
{
    public class Project : Entity
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
