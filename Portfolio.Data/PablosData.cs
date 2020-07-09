using System;
using System.Collections.Generic;
using System.Linq;
using Portfolio.Core;
using Portfolio.Core.DTOs;

namespace Portfolio.Data
{
    public class PablosData : IPablosData
    {
        #region Daos
        private readonly IRepository<Education> _educationDao;
        private readonly IRepository<Experience> _experienceDao;
        private readonly IRepository<Skill> _skillsDao;
        private readonly IRepository<Project> _projectDao;
        #endregion //Daos

        #region DataProperties
        private PersonalInformation Information;
        private IEnumerable<EducationDto> Education;
        private IEnumerable<ExperienceDto> Experience;
        private IEnumerable<ProjectDto> Projects;
        private IEnumerable<SkillDto> Skills;
        #endregion //Daos

        #region Constructor
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

            Education = GetEducation();

            Experience = GetExperience();

            Skills = GetSkills();

            Projects = GetPortafolio();
        }
        #endregion //Constructor

        #region Getters
        /// <summary>
        /// Returns the personal Information
        /// </summary>
        /// <returns></returns>
        public PersonalInformation GetInformation()
        {
            return Information;
        }

        /// <summary>
        /// Retrieves a list of education dto
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EducationDto> GetEducation()
        {
            Education = _educationDao.GetAll().Select(e => e.ToDto());
            return Education;
        }

        /// <summary>
        /// Retrieves a list of experience dto
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ExperienceDto> GetExperience()
        {
            Experience = _experienceDao.GetAll().Select(e => e.ToDto());
            return Experience;
        }

        /// <summary>
        /// Retrieves a list of projects dto
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectDto> GetPortafolio()
        {
            Projects = _projectDao.GetAll().Select(e => e.ToDto());
            return Projects;
        }

        /// <summary>
        /// Retrieves a list of Skills dto
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SkillDto> GetSkills()
        {
            Skills = _skillsDao.GetAll().Select(e => e.ToDto());
            return Skills;
        }

        #endregion //Getters

        #region Setters

        public string SetEducation(EducationDto educationDto)
        {
            string returnMessage;

            var education = educationDto.ToEntity();

            if (education.Id > 0)
            {
                _educationDao.Update(education);
                returnMessage = "Education updated";
            }
            else
            {
                _educationDao.Create(education);
                returnMessage = "Education created";
            }

            _educationDao.Commit();

            return returnMessage;
        }

        public string SetExperience(ExperienceDto experienceDto)
        {
            string returnMessage;

            var experience = experienceDto.ToEntity();

            if (experience.Id > 0)
            {
                _experienceDao.Update(experience);
                returnMessage = "Work updated";
            }
            else
            {
                _experienceDao.Create(experience);
                returnMessage = "Work created";
            }

            _experienceDao.Commit();

            return returnMessage;
        }

        public string SetProject(ProjectDto projectDto)
        {
            string returnMessage;

            var project = projectDto.ToEntity();

            if (project.Id > 0)
            {
                _projectDao.Update(project);
                returnMessage = "Project updated";
            }
            else
            {
                _projectDao.Create(project);
                returnMessage = "Project created";
            }

            _projectDao.Commit();

            return returnMessage;
        }

        public string SetSkill(SkillDto skillDto)
        {
            string returnMessage;

            var skill = skillDto.ToEntity();

            if (skill.Id > 0)
            {
                _skillsDao.Update(skill);
                returnMessage = "Skill updated";
            }
            else
            {
                _skillsDao.Create(skill);
                returnMessage = "Skill created";
            }

            _skillsDao.Commit();

            return returnMessage;
        }

        #endregion //Setters

        #region Get by Id

        /// <summary>
        /// This method returns an Experience DTO from a given Id
        /// </summary>
        /// <param name="id">Id of experience</param>
        /// <returns></returns>
        public ExperienceDto GetExperienceById(int id)
        {
            var experience = _experienceDao.Read(id);

            return new ExperienceDto
            {
                Id              = experience.Id,
                Company         = experience.Company,
                Position        = experience.Position,
                MainFunctions   = experience.MainFunctions,
                Technologies    = experience.Technologies,
                DateBegining    = experience.DateBegining,
                DateEnd         = experience.DateEnd,
                YearsExperience = experience.GetYearsExperience()
            };
        }
        #endregion // Get by Id

        #region Remove

        /// <summary>
        /// This method removes an experience from the Database
        /// </summary>
        /// <param name="id">Id of Experience to be removed</param>
        public void RemoveExperience(int id)
        {
            var experience = _experienceDao.Read(id);
            _experienceDao.Delete(experience);
            _experienceDao.Commit();
        }

        #endregion
    }
}
