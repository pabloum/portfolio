using Portfolio.Entities.Base;
using Portfolio.Entities.Entities;
using System;

namespace Portfolio.Entities.DTOs
{    
    public class EducationDto : EntityBase
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
