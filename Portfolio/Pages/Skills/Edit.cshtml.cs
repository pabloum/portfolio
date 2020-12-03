using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.Entities.DTOs;
using Portfolio.Entities;
using Portfolio.Data;

namespace Portfolio.Pages.Skills
{
    public class EditModel : PageModel
    {
        private readonly IOldRepository repository;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public SkillDto Skill { get; set; }
        public IEnumerable<SelectListItem> SkillTypes { get; set; }

        public EditModel(IOldRepository repository, IHtmlHelper htmlHelper)
        {
            this.repository = repository;
            this.htmlHelper = htmlHelper;

            SkillTypes = htmlHelper.GetEnumSelectList<SkillType>();
        }

        public IActionResult OnGet(int? skillId)
        {
            if (skillId.HasValue)
            {
                Skill = repository.GetSkillById(skillId.Value);
            }
            else
            {
                Skill = new SkillDto();
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
                repository.CreateSkill(Skill);
                return RedirectToPage("/index");
            }

            return Page();

        }
    }
}