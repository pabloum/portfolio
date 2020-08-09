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
    public class DetailModel : PageModel
    {
        private readonly IRepository repository;

        public ProjectDto Project { get; set; }

        public DetailModel(IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult OnGet(int projectId)
        {
            Project = repository.GetProjectById(projectId);

            return Page();
        }
    }
}