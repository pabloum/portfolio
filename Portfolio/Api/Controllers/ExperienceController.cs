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
            var experiences = repository.GetExperience();
            return Ok(experiences);
        }

        [HttpGet("{id}")]
        public ActionResult<ExperienceDto> GetById(int id)
        {            
            var experience = repository.GetExperienceById(id);
            if (experience == null) return NotFound($"The experience with Id {id} was not found");
            return Ok(experience);
        }

        [HttpPost]
        public ActionResult<ExperienceDto> Post(ExperienceDto experience)
        {            
            repository.CreateExperience(experience);
            return CreatedAtAction("GetExperience", experience);
        }

        [HttpPut]
        public IActionResult Put(ExperienceDto experience)
        {            
            repository.UpdateExperience(experience);
            return Ok("Experience updated");
        }

        [HttpPatch]
        public IActionResult Patch(ExperienceDto experience)
        {            
            repository.UpdateExperience(experience);
            return Ok("Experience updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {            
            repository.RemoveExperience(id);
            return Ok("Experience deleted");
        }
    }
}
