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
    public class DeleteEducationModel : PageModel
    {
        private readonly IRepository<Education> educationDao;
        public Education Education { get; set; }

        public DeleteEducationModel(IRepository<Education> educationDao)
        {
            this.educationDao = educationDao;
        }

        public IActionResult OnGet(int educationId)
        {
            Education = educationDao.Read(educationId);

            if (Education == null)
            {
                RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int educationId)
        {
            var education = educationDao.Read(educationId);
            educationDao.Delete(education);
            educationDao.Commit();

            if (education == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{education.Title} title from {education.University} was deleted";

            return RedirectToPage("/index");
        }
    }
}