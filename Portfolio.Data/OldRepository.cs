using System;
using System.Collections.Generic;
using System.Linq;
using Portfolio.Entities;
using Portfolio.Entities.Entities;
using Portfolio.Entities.DTOs;

namespace Portfolio.Data
{
    public class OldRepository : IOldRepository
    {
        #region Daos
        private readonly IDao<Education> _educationDao;
        private readonly IDao<Experience> _experienceDao;
        private readonly IDao<Skill> _skillsDao;
        private readonly IDao<Project> _projectDao;
        #endregion //Daos

        #region DataProperties
        private PersonalInformation Information;
        private IEnumerable<EducationDto> Education;
        private IEnumerable<ExperienceDto> Experience;
        private IEnumerable<ProjectDto> Projects;
        private IEnumerable<SkillDto> Skills;
        #endregion //Daos

        #region Constructor
        public OldRepository(IDao<Education> educationDao, IDao<Experience> experienceDao, 
                                   IDao<Skill> skillsDao, IDao<Project> projectDao)
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

        #region Create

        public string CreateEducation(EducationDto educationDto)
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

        public string CreateExperience(ExperienceDto experienceDto)
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

        public string CreateProject(ProjectDto projectDto)
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

        public string CreateSkill(SkillDto skillDto)
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

        #endregion //Create

        #region Update

        public EducationDto UpdateEducation(EducationDto educationDto)
        {
            if (educationDto.Id <= 0) return null;

            var education = educationDto.ToEntity();
            var updated = _educationDao.Update(education);
            _educationDao.Commit();

            return updated.ToDto();
        }

        public ExperienceDto UpdateExperience(ExperienceDto experienceDto)
        {
            if (experienceDto.Id <= 0) return null;

            var experience = experienceDto.ToEntity();
            var updated = _experienceDao.Update(experience);
            _experienceDao.Commit();

            return updated.ToDto();
        }

        public ProjectDto UpdateProject(ProjectDto projectDto)
        {
            if (projectDto.Id <= 0) return null;

            var project = projectDto.ToEntity();
            var updated = _projectDao.Update(project);
            _projectDao.Commit();

            return updated.ToDto();
        }

        public SkillDto UpdateSkill(SkillDto skillDto)
        {
            if (skillDto.Id <= 0) return null;

            var skill = skillDto.ToEntity();
            var updated = _skillsDao.Update(skill);
            _skillsDao.Commit();

            return updated.ToDto();
        }

        #endregion //Update

        #region Get by Id

        /// <summary>
        /// This method returns an Education DTO from a given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EducationDto GetEducationById(int id)
        {
            var education = _educationDao.Read(id);

            if (education == null) 
                return null;
            else
                return education.ToDto();
        }

        /// <summary>
        /// This method returns an Experience DTO from a given Id
        /// </summary>
        /// <param name="id">Id of experience</param>
        /// <returns></returns>
        public ExperienceDto GetExperienceById(int id)
        {
            var experience = _experienceDao.Read(id);

            if (experience == null)
                return null;
            else
                return experience.ToDto();
        }

        /// <summary>
        /// This method returns an Project DTO from a given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProjectDto GetProjectById(int id)
        {
            var project = _projectDao.Read(id);

            if (project == null)
                return null;
            else
                return project.ToDto();
        }

        /// <summary>
        /// This method returns an Skill DTO from a given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SkillDto GetSkillById(int id)
        {
            var skill = _skillsDao.Read(id);

            if (skill == null)
                return null;
            else
                return skill.ToDto();
        }

        #endregion // Get by Id

        #region Remove

        /// <summary>
        /// This method removes an education from the Database
        /// </summary>
        /// <param name="id">Id of the education to be deleted</param>
        public void RemoveEducation(int id)
        {
            var education = _educationDao.Read(id);
            _educationDao.Delete(education);
            _educationDao.Commit();
        }

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

        /// <summary>
        /// This method removes a project from the Database
        /// </summary>
        /// <param name="id">Id of the project to be deleted</param>
        public void RemoveProject(int id)
        {
            var project = _projectDao.Read(id);
            _projectDao.Delete(project);
            _projectDao.Commit();
        }

        /// <summary>
        /// This method removes a skill from the Database
        /// </summary>
        /// <param name="id">Id of the skill to be deleted</param>
        public void RemoveSkill(int id)
        {
            var skill = _skillsDao.Read(id);
            _skillsDao.Delete(skill);
            _skillsDao.Commit();
        }

        #endregion
    }
}
