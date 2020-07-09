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
    public class EditEducationModel : PageModel
    {
        private readonly IPablosData pablosData;

        [BindProperty]
        public EducationDto Education { get; set; }

        public EditEducationModel(IPablosData pablosData)
        {
            this.pablosData = pablosData;
        }
        public IActionResult OnGet(int? educationId)
        {
            if (educationId.HasValue)
            {
                Education = pablosData.GetEducationById(educationId.Value);
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
                TempData["Message"] = pablosData.SetEducation(Education);

                return RedirectToPage("/index");
            }

            return Page();
        }
    }
}