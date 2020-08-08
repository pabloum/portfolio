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
        private readonly IPablosData pablosData;

        public ProjectDto Project { get; set; }

        public DetailModel(IPablosData pablosData)
        {
            this.pablosData = pablosData;
        }

        public IActionResult OnGet(int projectId)
        {
            Project = pablosData.GetProjectById(projectId);

            return Page();
        }
    }
}