using Portfolio.Entities;
using Portfolio.Entities.DTOs;
using System.Collections.Generic;

namespace Portfolio.Data
{
    /// <summary>
    /// <see cref=""/>
    /// </summary>
    public interface IOldRepository
    {
        #region Getters
        /// <summary>
        /// Get personal information
        /// </summary>
        /// <returns></returns>
        PersonalInformation GetInformation();

        /// <summary>
        /// Returns the Education 
        /// </summary>
        /// <returns></returns>
        IEnumerable<EducationDto> GetEducation();

        /// <summary>
        /// Returns all the different jobs where the user has worked in.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ExperienceDto> GetExperience();

        /// <summary>
        /// Returns all the Projects the user has worked on
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProjectDto> GetPortafolio();

        /// <summary>
        /// Returns all the skills that the user has
        /// </summary>
        /// <returns></returns>
        IEnumerable<SkillDto> GetSkills();
        #endregion //Setter

        #region Create
        /// <summary>
        /// Create an education
        /// </summary>
        /// <param name="educationDto"></param>
        /// <returns>Returns a message which describes if an education was created or updated</returns>
        string CreateEducation(EducationDto educationDto);

        /// <summary>
        /// Create an experience
        /// </summary>
        /// <param name="experienceDto"></param>
        /// <returns>Returns a message which describes if an experience was created or updated</returns>
        string CreateExperience(ExperienceDto experienceDto);

        /// <summary>
        /// Create a new Skill
        /// </summary>
        /// <param name="skillDto"></param>
        /// <returns></returns>
        string CreateSkill(SkillDto skillDto);

        /// <summary>
        /// Create a new project
        /// </summary>
        /// <param name="projectDto"></param>
        /// <returns></returns>
        string CreateProject(ProjectDto projectDto);

        #endregion // Setters

        #region Update

        EducationDto UpdateEducation(EducationDto educationDto);
        ExperienceDto UpdateExperience(ExperienceDto experienceDto);
        ProjectDto UpdateProject(ProjectDto projectDto);
        SkillDto UpdateSkill(SkillDto skillDto);

        #endregion

        #region GetById

        EducationDto GetEducationById(int id);
        ExperienceDto GetExperienceById(int id);
        ProjectDto GetProjectById(int id);
        SkillDto GetSkillById(int id);

        #endregion //GetById

        #region Remove

        void RemoveEducation(int id);
        void RemoveExperience(int id);
        void RemoveProject(int id);
        void RemoveSkill(int id);
        #endregion //Remove

    }
}