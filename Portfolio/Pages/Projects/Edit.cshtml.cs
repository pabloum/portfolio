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
        private readonly IPablosData pablosData;

        [BindProperty]
        public ProjectDto Project { get; set; }

        public EditModel(IPablosData pablosData)
        {
            this.pablosData = pablosData;
        }

        public IActionResult OnGet(int? projectId)
        {
            if (projectId.HasValue)
            {
                Project = pablosData.GetProjectById(projectId.Value);
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
                TempData["Message"] = pablosData.SetProject(Project);

                return RedirectToPage("/index");
            }

            return Page();
        }
    }
}