using Portfolio.Data;
using Portfolio.Entities;
using Services;

namespace Portfolio.Services.Services
{
    public class PersonalInformationService : BaseService<PersonalInformation>
    {
        public PersonalInformationService(IRepository<PersonalInformation> repository) : base(repository)
        {
        }
    }
}
