using AutoMapper;
using Portfolio.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Core.Entities
{
    public class Education : Entity
    {
        public int Id { get; set; }
        public string University { get; set; }
        public string Title { get; set; }
        public DateTime DateBegining { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }

        public EducationDto ToDto()
        {
            return _mapper.Map<EducationDto>(this);
        }
    }
}
