using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Core.DTOs;
using Portfolio.Data;

namespace Portfolio
{
    public class DeleteExperienceModel : PageModel
    {
        private readonly IPablosData pablosData;

        public ExperienceDto Experience { get; set; }

        public DeleteExperienceModel(IPablosData pablosData)
        {
            this.pablosData = pablosData;
        }
        public IActionResult OnGet(int experienceId)
        {
            Experience = pablosData.GetExperienceById(experienceId);

            if (Experience == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int experienceId)
        {
            var experience = pablosData.GetExperienceById(experienceId);            

            pablosData.RemoveExperience(experienceId);

            if (experience == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{experience.Position} in {experience.Company} was deleted";

            return RedirectToPage("/index");
        }
    }
}