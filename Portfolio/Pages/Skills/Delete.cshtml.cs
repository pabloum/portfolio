using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Entities.DTOs;
using Portfolio.Data;

namespace Portfolio.Pages.Skills
{
    public class DeleteModel : PageModel
    {
        private readonly IPablosData pablosData;

        public SkillDto Skill { get; set; }

        public DeleteModel(IPablosData pablosData)
        {
            this.pablosData = pablosData;
        }
        public IActionResult OnGet(int skillId)
        {
            Skill = pablosData.GetSkillById(skillId);

            if (Skill == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int skillId)
        {
            var skill = pablosData.GetSkillById(skillId);

            pablosData.RemoveSkill(skillId);

            if (skill == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{skill.Name} was deleted";

            return RedirectToPage("/index");
        }
    }
}