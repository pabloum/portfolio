using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Core.DTOs;
using Portfolio.Data;

namespace Portfolio.Pages.Projects
{
    public class DeleteModel : PageModel
    {
        private readonly IPablosData pablosData;

        public ProjectDto Project { get; set; }

        public DeleteModel(IPablosData pablosData)
        {
            this.pablosData = pablosData;
        }

        public IActionResult OnGet(int projectId)
        {
            Project = pablosData.GetProjectById(projectId);

            if (Project == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int projectId)
        {
            var project = pablosData.GetProjectById(projectId);

            pablosData.RemoveProject(projectId);

            if (project == null)
            {
                return RedirectToPage("./NotFound");
            }
            
            TempData["Message"] = $"{project.ProjectName} was deleted";

            return RedirectToPage("/index");
        }
    }
}