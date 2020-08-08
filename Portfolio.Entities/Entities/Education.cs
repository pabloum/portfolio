using AutoMapper;
using Portfolio.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Entities.Entities
{
    public class Education : EntityBase
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
