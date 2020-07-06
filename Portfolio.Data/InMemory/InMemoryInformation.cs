using System;
using System.Collections.Generic;
using Portfolio.Core;

namespace Portfolio.Data.InMemory
{
    public class InMemoryInformation : IPablosData
    {
        private readonly IRepository<Education> _educationDao;
        private readonly IRepository<Experience> _experienceDao;
        private readonly IRepository<Skill> _skillsDao;
        private readonly IRepository<Project> _projectDao;

        public PersonalInformation Information { get; set; }
        public IEnumerable<Education> Education { get; set; }
        public IEnumerable<Experience> Experience { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Skill> Skills { get; set; }

        public InMemoryInformation(IRepository<Education> educationDao, IRepository<Experience> experienceDao, 
                                   IRepository<Skill> skillsDao, IRepository<Project> projectDao)
        {
            _educationDao = educationDao;
            _experienceDao = experienceDao;
            _skillsDao = skillsDao;
            _projectDao = projectDao;

            Information = new PersonalInformation
            {
                Name = "Pablo Uribe-Montoya",
                Birthday = DateTime.ParseExact("27/01/1994", "dd/MM/yyyy", null),
                PhoneNumber = "+57 3104735018",
                EmailAddress = "pablo.um00@gmail.com",
                Professions = new List<string> { "Aeronautical Engineer", "Mechanical Engineer" },
                Job = "Software developer",
                ProgrammingLanguages = new List<string> { "C/C++", "C#", "Python", "Javascript"},
                NaturalLanguages = new List<string> { "Spanish (native)", "English (C1)", "French (C1)", "German (B1)" }
            };

            Education = _educationDao.GetAll();

            Experience = _experienceDao.GetAll();

            Skills = _skillsDao.GetAll();

            Projects = _projectDao.GetAll();
        }

        /// <summary>
        /// Get the personal Information
        /// </summary>
        /// <returns></returns>
        public PersonalInformation GetInformation()
        {
            return Information;
        }

        public IEnumerable<Education> GetEducation()
        {
            Education = _educationDao.GetAll();
            return Education;
        }

        public IEnumerable<Experience> GetExperience()
        {
            Experience = _experienceDao.GetAll();
            return Experience;
        }

        public IEnumerable<Project> GetPortafolio()
        {
            Projects = _projectDao.GetAll();
            return Projects;
        }

        public IEnumerable<Skill> GetSkills()
        {
            Skills = _skillsDao.GetAll();
            return Skills;
        }
    }
}
