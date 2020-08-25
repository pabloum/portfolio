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
    public class ProjectsController : PortfolioBaseController
    {
        private readonly IRepository repository;

        public ProjectsController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProjectDto>> Get()
        {
            try
            {
                return Ok(repository.GetPortafolio());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ProjectDto> GetById(int id)
        {
            try
            {
                var project = repository.GetProjectById(id);
                if (project == null) return NotFound($"The project with Id {id} was not found");
                return Ok(project);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPost]
        public IActionResult Post(ProjectDto project)
        {
            try
            {
                repository.SetProject(project);
                return Ok("Created new project");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPut]
        public IActionResult Put(ProjectDto project)
        {
            try
            {
                repository.SetProject(project);
                return Ok("Project updated");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPatch]
        public IActionResult Patch(ProjectDto project)
        {
            try
            {
                repository.SetProject(project);
                return Ok("Project updated");
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
                repository.RemoveProject(id);
                return Ok("Project deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
    }
}
