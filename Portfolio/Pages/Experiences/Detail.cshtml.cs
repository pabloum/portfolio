using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Entities.DTOs;
using Portfolio.Data;

namespace Portfolio
{
    public class DetailExperienceModel : PageModel
    {
        private readonly IPablosData pablosData;

        public ExperienceDto Experience { get; set; }
        public DetailExperienceModel(IPablosData pablosData)
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
    }
}