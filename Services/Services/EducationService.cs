using Portfolio.Data;
using Portfolio.Entities.Entities;
using Services;

namespace Portfolio.Services.Services
{
    public class EducationService : BaseService<Education>
    {
        public EducationService(IRepository<Education> repository) : base(repository)
        {
        }
    }
}
