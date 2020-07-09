using Portfolio.Core;
using Portfolio.Core.DTOs;
using System.Collections.Generic;

namespace Portfolio.Data
{
    /// <summary>
    /// <see cref=""/>
    /// </summary>
    public interface IPablosData
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


        #region Setters
        /// <summary>
        /// Sets an education
        /// </summary>
        /// <param name="educationDto"></param>
        /// <returns>Returns a message which describes if an education was created or updated</returns>
        string SetEducation(EducationDto educationDto);

        /// <summary>
        /// Sets an experience
        /// </summary>
        /// <param name="experienceDto"></param>
        /// <returns>Returns a message which describes if an experience was created or updated</returns>
        string SetExperience(ExperienceDto experienceDto);

        /// <summary>
        /// Sets a new Skill
        /// </summary>
        /// <param name="skillDto"></param>
        /// <returns></returns>
        string SetSkill(SkillDto skillDto);

        /// <summary>
        /// Sets a new project
        /// </summary>
        /// <param name="projectDto"></param>
        /// <returns></returns>
        string SetProject(ProjectDto projectDto);

        #endregion // Setters

        #region GetById
        /// <summary>
        /// Returns an ExperienceDTO with the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ExperienceDto GetExperienceById(int id);

        #endregion //GetById

        #region Remove

        /// <summary>
        /// Removes the Experience from the DB with the given Id
        /// </summary>
        /// <param name="id"></param>
        void RemoveExperience(int id);
        #endregion //Remove

    }
}