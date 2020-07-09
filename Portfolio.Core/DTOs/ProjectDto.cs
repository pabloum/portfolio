using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Core.DTOs
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Technologies { get; set; }
        public string Description { get; set; }

        public Project ToEntity()
        {
            return new Project
            {
                Id           = this.Id,
                ProjectName  = this.ProjectName,
                Technologies = this.Technologies,
                Description  = this.Description
            };
        }
    }
}
