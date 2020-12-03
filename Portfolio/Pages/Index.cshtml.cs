using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Portfolio.Entities;
using Portfolio.Entities.DTOs;
using Portfolio.Data;

namespace Portfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IOldRepository repository;
        private readonly IHtmlHelper htmlHelper;

        public PersonalInformation Information { get; set; }
        public IEnumerable<EducationDto> Education { get; set; }
        public IEnumerable<ExperienceDto> Experience { get; set; }
        public IEnumerable<SkillDto> Skills { get; set; }
        public IEnumerable<ProjectDto> Portafolio { get; set; }
        public IEnumerable<SelectListItem> SkillTypes { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IOldRepository repository, IHtmlHelper htmlHelper)
        {
            _logger = logger;
            this.repository = repository;
            this.htmlHelper = htmlHelper;

            SkillTypes = htmlHelper.GetEnumSelectList<SkillType>();
        }

        public void OnGet()
        {
            Information = repository.GetInformation();
            Education = repository.GetEducation();
            Experience = repository.GetExperience();
            Portafolio = repository.GetPortafolio();
            Skills =    repository.GetSkills();
        }
    }
}
