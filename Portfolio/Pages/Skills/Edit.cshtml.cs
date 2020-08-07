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
        private readonly IPablosData pablosData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public SkillDto Skill { get; set; }
        public IEnumerable<SelectListItem> SkillTypes { get; set; }

        public EditModel(IPablosData pablosData, IHtmlHelper htmlHelper)
        {
            this.pablosData = pablosData;
            this.htmlHelper = htmlHelper;

            SkillTypes = htmlHelper.GetEnumSelectList<SkillType>();
        }

        public IActionResult OnGet(int? skillId)
        {
            if (skillId.HasValue)
            {
                Skill = pablosData.GetSkillById(skillId.Value);
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
                pablosData.SetSkill(Skill);
                return RedirectToPage("/index");
            }

            return Page();

        }
    }
}