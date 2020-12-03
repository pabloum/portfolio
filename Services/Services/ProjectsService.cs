using Portfolio.Data;
using Portfolio.Entities.Entities;
using Services;

namespace Portfolio.Services.Services
{
    public class ProjectsService : BaseService<Project>
    {
        public ProjectsService(IRepository<Project> repository) : base(repository)
        {
        }
    }
}
