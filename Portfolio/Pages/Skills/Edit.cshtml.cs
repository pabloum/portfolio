using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.Core;
using Portfolio.Data;

namespace Portfolio.Pages.Skills
{
    public class EditModel : PageModel
    {
        private readonly IRepository<Skill> skillDao;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Skill Skill { get; set; }
        public IEnumerable<SelectListItem> SkillTypes { get; set; }

        public EditModel(IRepository<Skill> skillDao, IHtmlHelper htmlHelper)
        {
            this.skillDao = skillDao;
            this.htmlHelper = htmlHelper;

            SkillTypes = htmlHelper.GetEnumSelectList<SkillType>();
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

                skillDao.Commit();

                return RedirectToPage("/index");
            }

            return Page();

        }
    }
}