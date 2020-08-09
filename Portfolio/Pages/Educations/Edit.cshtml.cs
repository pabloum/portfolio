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
    public class EditEducationModel : PageModel
    {
        private readonly IRepository repository;

        [BindProperty]
        public EducationDto Education { get; set; }

        public EditEducationModel(IRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult OnGet(int? educationId)
        {
            if (educationId.HasValue)
            {
                Education = repository.GetEducationById(educationId.Value);
            }
            else
            {
                Education = new EducationDto();
            }

            if (Education == null)
            {
                return RedirectToPage("/index");
            }

            return Page();
        }
        
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = repository.SetEducation(Education);

                return RedirectToPage("/index");
            }

            return Page();
        }
    }
}