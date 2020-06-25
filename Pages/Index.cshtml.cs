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
        private readonly IPablosData pablosData;

        public PersonalInformation Pablo { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IPablosData pablosData)
        {
            _logger = logger;
            this.pablosData = pablosData;
        }

        public void OnGet()
        {
            Pablo = pablosData.GetInformation();
        }
    }
}
