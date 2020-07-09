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
    }
}
