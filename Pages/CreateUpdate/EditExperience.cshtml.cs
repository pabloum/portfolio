﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Core;
using Portfolio.Data;

namespace Portfolio
{
    public class EditExperienceModel : PageModel
    {
        private readonly IRepository<Experience> experienceDao;

        [BindProperty]
        public Experience Experience { get; set; }

        public EditExperienceModel(IRepository<Experience> experienceDao)
        {
            this.experienceDao = experienceDao;
        }

        public IActionResult OnGet(int? experienceId)
        {
            if (experienceId.HasValue)
            {
                Experience = experienceDao.Read(1);
            }
            else
            {
                Experience = new Experience();
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
                if (false) // ToDo:: Restaurant.Id > 0
                {
                    TempData["Message"] = "Study updated!";
                    experienceDao.Update(Experience);
                }
                else
                {
                    TempData["Message"] = "Study created!";
                    experienceDao.Create(Experience);
                }

                //pablosData.Commit();

                return RedirectToPage("/index");
            }

            return Page();
        }
    }
}