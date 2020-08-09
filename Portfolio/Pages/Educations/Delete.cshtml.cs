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
    public class DeleteEducationModel : PageModel
    {
        private readonly IRepository repository;
        public EducationDto Education { get; set; }

        public DeleteEducationModel(IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult OnGet(int educationId)
        {
            Education = repository.GetEducationById(educationId);

            if (Education == null)
            {
                RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int educationId)
        {
            var education = repository.GetEducationById(educationId);

            repository.RemoveEducation(educationId);

            if (education == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{education.Title} title from {education.University} was deleted";

            return RedirectToPage("/index");
        }
    }
}