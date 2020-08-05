using AutoMapper;
using Portfolio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Core.DTOs
{
    public class ProjectDto : Entity
    {
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
