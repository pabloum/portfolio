using Portfolio.Entities.Base;
using Portfolio.Entities.DTOs;
using System;

namespace Portfolio.Entities.Entities
{
    public class Education : BaseEntity
    {
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
