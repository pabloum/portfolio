using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Core;
using Portfolio.Data;

namespace Portfolio.Pages.Skills
{
    public class EditModel : PageModel
    {
        private readonly IRepository<Skill> skillDao;

        [BindProperty]
        public Skill Skill { get; set; }

        public EditModel(IRepository<Skill> skillDao)
        {
            this.skillDao = skillDao;
        }
        public IActionResult OnGet(int? skillId)
        {
            if (skillId.HasValue)
            {
                Skill = skillDao.Read(skillId.Value);
            }
            else
            {
                Skill = new Skill();
            }

            if (Skill == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Skill.Id > 0)
                {
                    TempData["Message"] = "Study updated!";
                    skillDao.Update(Skill);
                }
                else
                {
                    TempData["Message"] = "Study created!";
                    skillDao.Create(Skill);
                }

                //pablosData.Commit();

                return RedirectToPage("/index");
            }

            return Page();

        }
    }
}