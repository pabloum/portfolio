using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Entities.DTOs;
using Portfolio.Data;

namespace Portfolio.Pages.Projects
{
    public class DeleteModel : PageModel
    {
        private readonly IOldRepository repository;

        public ProjectDto Project { get; set; }

        public DeleteModel(IOldRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult OnGet(int projectId)
        {
            Project = repository.GetProjectById(projectId);

            if (Project == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int projectId)
        {
            var project = repository.GetProjectById(projectId);

            repository.RemoveProject(projectId);

            if (project == null)
            {
                return RedirectToPage("./NotFound");
            }
            
            TempData["Message"] = $"{project.ProjectName} was deleted";

            return RedirectToPage("/index");
        }
    }
}