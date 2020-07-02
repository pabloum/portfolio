using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Core;
using Portfolio.Data;

namespace Portfolio
{
    public class DeleteExperienceModel : PageModel
    {
        private readonly IRepository<Experience> experienceDao;

        public Experience Experience { get; set; }

        public DeleteExperienceModel(IRepository<Experience> experienceDao)
        {
            this.experienceDao = experienceDao;
        }
        public IActionResult OnGet(int experienceId)
        {
            Experience = experienceDao.Read(experienceId);

            if (Experience == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int experienceId)
        {
            var experience = experienceDao.Read(experienceId);

            experienceDao.Delete(experience);
            experienceDao.Commit();

            if (experience == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{experience.Position} in {experience.Company} was deleted";

            return RedirectToPage("/index");
        }
    }
}