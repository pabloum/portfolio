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
            try
            {
                var educations = repository.GetEducation();
                return Ok(educations);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<EducationDto> GetById(int id)
        {
            try
            {
                var education = repository.GetEducationById(id);
                if (education == null) return NotFound($"The education with Id {id} was not found");
                return Ok(education);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPost]
        public IActionResult Post(EducationDto education)
        {
            try
            {
                repository.CreateEducation(education);
                return Ok("New education created");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPut]
        public IActionResult Put(EducationDto education)
        {
            try
            {
                repository.UpdateEducation(education);
                return Ok("Education updated");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPatch]
        public IActionResult Patch(EducationDto education)
        {
            try
            {
                repository.UpdateEducation(education);
                return Ok("Education updated");
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
                repository.RemoveEducation(id);
                return Ok("Education deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
    }
}
