using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Core;
using Portfolio.Data;

namespace Portfolio
{
    public class DetailEducationModel : PageModel
    {
        private readonly IRepository<Education> educationDao;

        public Education Education { get; set; }

        public DetailEducationModel(IRepository<Education> educationDao)
        {
            this.educationDao = educationDao;
        }

        public void OnGet(int educationId)
        {
            Education = educationDao.Read(educationId);
        }
    }
}