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
    public class EditModel : PageModel
    {
        private readonly IRepository repository;

        [BindProperty]
        public ProjectDto Project { get; set; }

        public EditModel(IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult OnGet(int? projectId)
        {
            if (projectId.HasValue)
            {
                Project = repository.GetProjectById(projectId.Value);
            }
            else
            {
                Project = new ProjectDto();
            }

            if (Project == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = repository.CreateProject(Project);

                return RedirectToPage("/index");
            }

            return Page();
        }
    }
}