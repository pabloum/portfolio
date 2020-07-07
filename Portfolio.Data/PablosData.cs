﻿using System;
using System.Collections.Generic;
using System.Linq;
using Portfolio.Core;
using Portfolio.Core.DTOs;

namespace Portfolio.Data
{
    public class PablosData : IPablosData
    {
        private readonly IRepository<Education> _educationDao;
        private readonly IRepository<Experience> _experienceDao;
        private readonly IRepository<Skill> _skillsDao;
        private readonly IRepository<Project> _projectDao;

        public PersonalInformation Information { get; set; }
        public IEnumerable<Education> Education { get; set; }
        public IEnumerable<ExperienceDto> Experience { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Skill> Skills { get; set; }

        public PablosData(IRepository<Education> educationDao, IRepository<Experience> experienceDao, 
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

            Experience = GetExperience();

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

        public IEnumerable<ExperienceDto> GetExperience()
        {
            Experience = _experienceDao.GetAll().Select(
                e => new ExperienceDto { 
                        Company = e.Company,
                        Position = e.Position,
                        MainFunctions = e.MainFunctions,
                        Technologies = e.Technologies,
                        DateBegining = e.DateBegining,
                        DateEnd = e.DateEnd,
                        YearsExperience = e.GetYearsExperience()
                }
            );

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
