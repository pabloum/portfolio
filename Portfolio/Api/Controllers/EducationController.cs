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
    public class EducationController : PortfolioBaseController
    {
        private readonly IRepository repository;

        public EducationController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var educations = repository.GetEducation();
            return Ok(educations);
        }

        [HttpGet("{id}")]
        public ActionResult<EducationDto> GetById(int id)
        {
            var education = repository.GetEducationById(id);
            if (education == null) return NotFound($"The education with Id {id} was not found");
            return Ok(education);
        }

        [HttpPost]
        public ActionResult<EducationDto> Post(EducationDto education)
        {
            repository.CreateEducation(education);
            return CreatedAtAction("GetEducation", education);
        }

        [HttpPut]
        public IActionResult Put(EducationDto education)
        {
            repository.UpdateEducation(education);
            return Ok("Education updated");
        }

        [HttpPatch]
        public IActionResult Patch(EducationDto education)
        {
            repository.UpdateEducation(education);
            return Ok("Education updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {            
            repository.RemoveEducation(id);
            return Ok("Education deleted");
        }
    }
}
