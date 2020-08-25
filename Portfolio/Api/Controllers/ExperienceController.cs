using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Base;
using Portfolio.Data;
using Portfolio.Entities.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Portfolio.Api.Controllers
{
    public class ExperienceController : PortfolioBaseController
    {
        private readonly IRepository repository;

        public ExperienceController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ExperienceDto>> Get()
        {
            try
            {
                var experiences = repository.GetExperience();

                return Ok(experiences);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ExperienceDto> GetById(int id)
        {
            try
            {
                var experience = repository.GetExperienceById(id);
                if (experience == null) return NotFound($"The experience with Id {id} was not found");
                return Ok(experience);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPost]
        public IActionResult Post(ExperienceDto experience)
        {
            try
            {
                repository.SetExperience(experience);
                return Ok("Created new experience");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPut]
        public IActionResult Put(ExperienceDto experience)
        {
            try
            {
                repository.SetExperience(experience);
                return Ok("Experience updated");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPatch]
        public IActionResult Patch(ExperienceDto experience)
        {
            try
            {
                repository.SetExperience(experience);
                return Ok("Experience updated");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                repository.RemoveExperience(id);
                return Ok("Experience deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
    }
}
