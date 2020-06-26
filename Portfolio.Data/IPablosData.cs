using Portfolio.Core;
using System.Collections.Generic;

namespace Portfolio.Data
{
    public interface IPablosData
    {
        PersonalInformation GetInformation();
        List<Education> GetEducation();
        List<Experience> GetExperience();
        List<Project> GetPortafolio();
        List<Skill> GetSkills();
    }
}
