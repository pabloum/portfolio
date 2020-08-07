using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Entities.DTOs;
using Portfolio.Data;

namespace Portfolio
{
    public class DetailEducationModel : PageModel
    {
        private readonly IPablosData pablosData;

        public EducationDto Education { get; set; }

        public DetailEducationModel(IPablosData pablosData)
        {
            this.pablosData = pablosData;
        }

        public void OnGet(int educationId)
        {
            Education = pablosData.GetEducationById(educationId);
        }
    }
}