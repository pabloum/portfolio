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
            return Ok(repository.GetSkills());
        }

        [HttpGet("{id}")]
        public ActionResult<SkillDto> GetById(int id)
        {
            var skill = repository.GetSkillById(id);
            if (skill == null) return NotFound($"The skill with Id {id} was not found");
            return Ok(skill);
        }

        [HttpPost]
        public ActionResult<SkillDto> Post(SkillDto skill)
        {
            repository.CreateSkill(skill);
            return CreatedAtAction("GetSkill", skill);
        }

        [HttpPut]
        public IActionResult Put(SkillDto skill)
        {
            repository.UpdateSkill(skill);
            return Ok("Skill updated");
        }

        [HttpPatch]
        public IActionResult Patch(SkillDto skill)
        {
            repository.UpdateSkill(skill);
            return Ok("Skill updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repository.RemoveSkill(id);
            return Ok("Skill deleted");
        }
    }
}
