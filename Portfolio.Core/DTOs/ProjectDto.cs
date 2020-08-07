using AutoMapper;
using Portfolio.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Entities.DTOs
{
    public class ProjectDto : EntityBase
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
