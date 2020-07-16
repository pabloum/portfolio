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
    public class EditExperienceModel : PageModel
    {
        private readonly IPablosData pablosData;

        [BindProperty]
        public ExperienceDto Experience { get; set; }

        public EditExperienceModel(IPablosData pablosData)
        {
            this.pablosData = pablosData;
        }

        public IActionResult OnGet(int? experienceId)
        {
            if (experienceId.HasValue)
            {
                Experience = pablosData.GetExperienceById(experienceId.Value);
            }
            else
            {
                Experience = new ExperienceDto();
            }

            if (Experience == null)
            {
                return RedirectToPage("/index");
            }

            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var msg = pablosData.SetExperience(Experience);
                TempData["Message"] = msg;

                return RedirectToPage("/index");
            }

            return Page();
        }
    }
}