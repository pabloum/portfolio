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
    public class DeleteEducationModel : PageModel
    {
        private readonly IPablosData pablosData;
        public EducationDto Education { get; set; }

        public DeleteEducationModel(IPablosData pablosData)
        {
            this.pablosData = pablosData;
        }

        public IActionResult OnGet(int educationId)
        {
            Education = pablosData.GetEducationById(educationId);

            if (Education == null)
            {
                RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int educationId)
        {
            var education = pablosData.GetEducationById(educationId);

            pablosData.RemoveEducation(educationId);

            if (education == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{education.Title} title from {education.University} was deleted";

            return RedirectToPage("/index");
        }
    }
}