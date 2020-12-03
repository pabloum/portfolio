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
        private readonly IOldRepository repository;

        public ProjectsController(IOldRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProjectDto>> Get()
        {
            return Ok(repository.GetPortafolio());
        }

        [HttpGet("{id}")]
        public ActionResult<ProjectDto> GetById(int id)
        {
            var project = repository.GetProjectById(id);
            if (project == null) return NotFound($"The project with Id {id} was not found");
            return Ok(project);
        }

        [HttpPost]
        public ActionResult<ProjectDto> Post(ProjectDto project)
        {
            repository.CreateProject(project);
            return CreatedAtAction("GetProjects", project);
        }

        [HttpPut]
        public IActionResult Put(ProjectDto project)
        {
            repository.UpdateProject(project);
            return Ok("Project updated");
        }

        [HttpPatch]
        public IActionResult Patch(ProjectDto project)
        {
            repository.UpdateProject(project);
            return Ok("Project updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repository.RemoveProject(id);
            return Ok("Project deleted");
        }
    }
}
