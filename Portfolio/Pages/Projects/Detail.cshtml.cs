using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Core;
using Portfolio.Data;

namespace Portfolio.Pages.Projects
{
    public class DetailModel : PageModel
    {
        private readonly IRepository<Project> projectDao;

        public Project Project { get; set; }

        public DetailModel(IRepository<Project> projectDao)
        {
            this.projectDao = projectDao;
        }

        public IActionResult OnGet(int projectId)
        {
            Project = projectDao.Read(projectId);

            return Page();
        }
    }
}