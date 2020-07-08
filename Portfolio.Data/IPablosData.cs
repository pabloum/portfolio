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
        /// <summary>
        /// Get personal information
        /// </summary>
        /// <returns></returns>
        PersonalInformation GetInformation();

        /// <summary>
        /// Returns the Education 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Education> GetEducation();

        /// <summary>
        /// Returns all the different jobs where the user has worked in.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ExperienceDto> GetExperience();

        /// <summary>
        /// Returns all the Projects the user has worked on
        /// </summary>
        /// <returns></returns>
        IEnumerable<Project> GetPortafolio();

        /// <summary>
        /// Returns all the skills that the user has
        /// </summary>
        /// <returns></returns>
        IEnumerable<Skill> GetSkills();

        /// <summary>
        /// Sets an experience
        /// </summary>
        /// <param name="experienceDto"></param>
        /// <returns>Returns a message which describes if an experience was created or updated</returns>
        string SetExperience(ExperienceDto experienceDto);

        ExperienceDto GetExperienceById(int id);

        void RemoveExperience(int id);

    }
}