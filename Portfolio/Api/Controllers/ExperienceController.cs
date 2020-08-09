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
    }
}
