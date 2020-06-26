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
    public class EditEducationModel : PageModel
    {
        private readonly IRepository<Education> educationDao;

        [BindProperty]
        public Education Education { get; set; }

        public EditEducationModel(IRepository<Education> educationDao)
        {
            this.educationDao = educationDao;
        }
        public IActionResult OnGet(int? educationId)
        {
            if (educationId.HasValue)
            {
                Education = educationDao.Read(1);
            }
            else
            {
                Education = new Education();
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
                if (false) // ToDo:: Restaurant.Id > 0
                {
                    TempData["Message"] = "Study updated!";
                    educationDao.Update(Education);
                }
                else
                {
                    TempData["Message"] = "Study created!";
                    educationDao.Create(Education);
                }

                //pablosData.Commit();

                return RedirectToPage("/index");
            }

            return Page();
        }
    }
}