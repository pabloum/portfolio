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
        private readonly IRepository repository;

        public SkillDto Skill { get; set; }

        public DeleteModel(IRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult OnGet(int skillId)
        {
            Skill = repository.GetSkillById(skillId);

            if (Skill == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int skillId)
        {
            var skill = repository.GetSkillById(skillId);

            repository.RemoveSkill(skillId);

            if (skill == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{skill.Name} was deleted";

            return RedirectToPage("/index");
        }
    }
}