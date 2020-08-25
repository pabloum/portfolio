using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Base;
using Portfolio.Data;
using Portfolio.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Api.Controllers
{
    public class SkillsController : PortfolioBaseController
    {
        private readonly IRepository repository;

        public SkillsController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(repository.GetSkills());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<SkillDto> GetById(int id)
        {
            try
            {
                var skill = repository.GetSkillById(id);
                if (skill == null) return NotFound($"The skill with Id {id} was not found");
                return Ok(skill);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPost]
        public IActionResult Post(SkillDto skill)
        {
            try
            {
                repository.CreateSkill(skill);
                return Ok("Created new skill");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPut]
        public IActionResult Put(SkillDto skill)
        {
            try
            {
                repository.UpdateSkill(skill);
                return Ok("Skill updated");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPatch]
        public IActionResult Patch(SkillDto skill)
        {
            try
            {
                repository.UpdateSkill(skill);
                return Ok("Skill updated");
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
                repository.RemoveSkill(id);
                return Ok("Skill deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
    }
}
