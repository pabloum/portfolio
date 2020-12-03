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
        private readonly IOldRepository repository;

        public ExperienceDto Experience { get; set; }
        public DetailExperienceModel(IOldRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult OnGet(int experienceId)
        {
            Experience = repository.GetExperienceById(experienceId);

            if (Experience == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}