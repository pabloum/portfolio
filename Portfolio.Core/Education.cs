﻿using Portfolio.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Core
{
    public class Education
    {
        public int Id { get; set; }
        public string University { get; set; }
        public string Title { get; set; }
        public DateTime DateBegining { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }

        public EducationDto ToDto()
        {
            return new EducationDto
            {
                Id           = this.Id,
                University   = this.University,
                Title        = this.Title,
                DateBegining = this.DateBegining,
                DateEnd      = this.DateEnd,
                Description  = this.Description
            };
        }
    }
}
