using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Portfolio.Core;
using Portfolio.Core.DTOs;
using Portfolio.Data;

namespace Portfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPablosData PablosData;
        private readonly IHtmlHelper htmlHelper;

        public PersonalInformation Information { get; set; }
        public IEnumerable<Education> Education { get; set; }
        public IEnumerable<ExperienceDto> Experience { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public IEnumerable<Project> Portafolio { get; set; }
        public IEnumerable<SelectListItem> SkillTypes { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IPablosData pablosData, IHtmlHelper htmlHelper)
        {
            _logger = logger;
            this.PablosData = pablosData;
            this.htmlHelper = htmlHelper;

            SkillTypes = htmlHelper.GetEnumSelectList<SkillType>();
        }

        public void OnGet()
        {
            Information = PablosData.GetInformation();
            Education = PablosData.GetEducation();
            Experience = PablosData.GetExperience();
            Portafolio = PablosData.GetPortafolio();
            Skills =    PablosData.GetSkills();
        }
    }
}
