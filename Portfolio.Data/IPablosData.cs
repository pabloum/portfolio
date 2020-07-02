using Portfolio.Core;
using System.Collections.Generic;

namespace Portfolio.Data
{
    public interface IPablosData
    {
        PersonalInformation GetInformation();
        IEnumerable<Education> GetEducation();
        IEnumerable<Experience> GetExperience();
        IEnumerable<Project> GetPortafolio();
        IEnumerable<Skill> GetSkills();
    }
}
