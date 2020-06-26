using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Portfolio.Core;
using Portfolio.Data;

namespace Portfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPablosData PablosData;

        public PersonalInformation Information { get; set; }
        public List<Education> Education { get; set; }
        public List<Experience> Experience { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Project> Portafolio { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IPablosData pablosData)
        {
            _logger = logger;
            this.PablosData = pablosData;
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
