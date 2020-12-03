using Portfolio.Entities.Base;
using Portfolio.Entities.DTOs;

namespace Portfolio.Entities.Entities
{
    public class Project : EntityBase
    {
        public string ProjectName { get; set; }
        public string Technologies { get; set; }
        public string Description { get; set; }

        public ProjectDto ToDto()
        {
            return _mapper.Map<ProjectDto>(this);
        }
    }
}
