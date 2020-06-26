﻿using System;
using System.Collections.Generic;
using Portfolio.Core;

namespace Portfolio.Data
{
    public class InMemoryInformation : IPablosData
    {
        private readonly IRepository<Education> _educationDao;
        private readonly IRepository<Experience> _experienceDao;

        public PersonalInformation Information { get; set; }
        public List<Education> Education { get; set; }
        public List<Experience> Experience { get; set; }
        public List<Project> Projects { get; set; }

        public InMemoryInformation(IRepository<Education> educationDao, IRepository<Experience> experienceDao)
        {
            _educationDao = educationDao;
            _experienceDao = experienceDao;

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

            Education = (List<Education>)_educationDao.GetAll();

            Experience = (List<Experience>)_experienceDao.GetAll();

            Projects = new List<Project>
            {
                new Project { }
            };
        }

        public PersonalInformation GetInformation()
        {
            return Information;
        }

        public List<Education> GetEducation()
        {
            Education = (List<Education>)_educationDao.GetAll();
            return Education;
        }

        public List<Experience> GetExperience()
        {
            Experience = (List<Experience>)_experienceDao.GetAll();
            return Experience;
        }

        public List<Project> GetPortafolio()
        {
            return Projects;
        }
    }
}
