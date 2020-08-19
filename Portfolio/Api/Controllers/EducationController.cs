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
                if (educations == null) return NotFound($"No educations were found");
                return Ok(educations);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<EducationDto> GetEducationById(int id)
        {
            try
            {
                var education = repository.GetEducationById(id);
                if (education == null) return NotFound($"The education with Id {id} was not found");
                return Ok(education);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
