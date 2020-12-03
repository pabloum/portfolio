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
    public class EditExperienceModel : PageModel
    {
        private readonly IOldRepository repository;

        [BindProperty]
        public ExperienceDto Experience { get; set; }

        public EditExperienceModel(IOldRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult OnGet(int? experienceId)
        {
            if (experienceId.HasValue)
            {
                Experience = repository.GetExperienceById(experienceId.Value);
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
                var msg = repository.CreateExperience(Experience);
                TempData["Message"] = msg;

                return RedirectToPage("/index");
            }

            return Page();
        }
    }
}