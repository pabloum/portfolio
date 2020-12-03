using Portfolio.Data;
using Portfolio.Entities.Entities;
using Services;

namespace Portfolio.Services.Services
{
    public class SkillService : BaseService<Skill>
    {
        public SkillService(IRepository<Skill> repository) : base(repository)
        {
        }
    }
}
