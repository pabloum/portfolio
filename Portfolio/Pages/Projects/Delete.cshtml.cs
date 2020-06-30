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
    public class DeleteModel : PageModel
    {
        private readonly IRepository<Project> projectDao;

        public Project Project { get; set; }

        public DeleteModel(IRepository<Project> projectDao)
        {
            this.projectDao = projectDao;
        }

        public IActionResult OnGet(int projectId)
        {
            Project = projectDao.Read(projectId);

            if (Project == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int projectId)
        {
            var project = projectDao.Read(projectId);

            projectDao.Delete(project);
            //projectDao.Commit();

            if (project == null)
            {
                return RedirectToPage("./NotFound");
            }
            
            TempData["Message"] = $"{project.ProjectName} was deleted";

            return RedirectToPage("/index");
        }
    }
}