using Portfolio.Api.Base;
using Portfolio.Data;
using Portfolio.Entities.Entities;
using Services;

namespace Portfolio.Api.Controllers
{
    public class ExperienceController : PortfolioGenericController<Experience>
    {
        public ExperienceController(IBaseService<Experience> service) : base(service)
        {
        }
    }
}
