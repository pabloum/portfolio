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
    public class DeleteModel : PageModel
    {
        private readonly IRepository<Skill> skillDao;

        public Skill Skill { get; set; }

        public DeleteModel(IRepository<Skill> skillDao)
        {
            this.skillDao = skillDao;
        }
        public IActionResult OnGet(int skillId)
        {
            Skill = skillDao.Read(skillId);

            if (Skill == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int skillId)
        {
            var skill = skillDao.Read(skillId);

            skillDao.Delete(skill);
            //skillDao.Commit();

            if (skill == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{skill.Name} was deleted";

            return RedirectToPage("/index");
        }
    }
}