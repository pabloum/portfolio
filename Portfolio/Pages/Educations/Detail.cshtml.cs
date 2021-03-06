﻿using System;
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
        private readonly IRepository repository;

        public EducationDto Education { get; set; }

        public DetailEducationModel(IRepository repository)
        {
            this.repository = repository;
        }

        public void OnGet(int educationId)
        {
            Education = repository.GetEducationById(educationId);
        }
    }
}