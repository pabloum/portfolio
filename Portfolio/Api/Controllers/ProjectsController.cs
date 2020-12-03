using Portfolio.Api.Base;
using Portfolio.Entities.Entities;
using Services;

namespace Portfolio.Api.Controllers
{
    public class ProjectsController : PortfolioGenericController<Project>
    {
        public ProjectsController(IBaseService<Project> service) : base(service)
        {
        }
    }
}
