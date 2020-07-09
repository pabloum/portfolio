using Portfolio.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Core
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Technologies { get; set; }
        public string Description { get; set; }

        public ProjectDto ToDto()
        {
            return new ProjectDto {
                Id           = this.Id,
                ProjectName  = this.ProjectName,
                Technologies = this.Technologies,
                Description  = this.Description
            };
        }
    }
}
