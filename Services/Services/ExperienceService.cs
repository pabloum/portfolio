using Portfolio.Data;
using Portfolio.Entities.Entities;
using Services;

namespace Portfolio.Services.Services
{
    public class ExperienceService : BaseService<Experience>
    {
        public ExperienceService(IRepository<Experience> repository) : base(repository)
        {
        }
    }
}
