using AutoMapper;
using Portfolio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Core.DTOs
{    
    public class EducationDto : Entity
    {
        public int Id { get; set; }
        public string University { get; set; }
        public string Title { get; set; }
        public DateTime DateBegining { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }

        public Education ToEntity()
        {
            return _mapper.Map<Education>(this);
        }
    }
}
