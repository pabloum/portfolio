using Portfolio.Api.Base;
using Portfolio.Entities.Entities;
using Services;

namespace Portfolio.Api.Controllers
{
    public class SkillsController : PortfolioGenericController<Skill>
    {
        public SkillsController(IBaseService<Skill> service) : base(service)
        {
        }
    }
}
