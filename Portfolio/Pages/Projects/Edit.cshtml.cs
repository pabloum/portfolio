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
    public class EditModel : PageModel
    {
        private readonly IRepository<Project> projectDao;

        [BindProperty]
        public Project Project { get; set; }

        public EditModel(IRepository<Project> projectDao)
        {
            this.projectDao = projectDao;
        }

        public IActionResult OnGet(int? projectId)
        {
            if (projectId.HasValue)
            {
                Project = projectDao.Read(projectId.Value);
            }
            else
            {
                Project = new Project();
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
                if (Project.Id > 0)
                {
                    TempData["Message"] = "Project created!";
                    projectDao.Update(Project);
                }
                else
                {
                    TempData["Message"] = "Project created!";
                    projectDao.Create(Project);
                }

                //projectDao.Commit();

                return RedirectToPage("/index");
            }

            return Page();
        }
    }
}