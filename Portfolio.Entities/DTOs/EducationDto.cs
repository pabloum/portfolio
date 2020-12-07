using Portfolio.Entities.Base;
using Portfolio.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Entities.DTOs
{    
    public class EducationDto : BaseDto
    {
        [CheckUniversity]
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

    public class CheckUniversity : ValidationAttribute
    {
        private List<string> UniversityName = new List<string>();
        public CheckUniversity()
        {
            UniversityName = new List<string>
            {
                "Universidad de los Andes",
                "Universidad EAFIT",
                "Universidad EIA",
                "Universidad Pontificia Bolivariana",
                "Javeriana",
                "Universidad de Medellín",
                "Universidad Nacional",
                "Universidad de Antioquia",
                "Politénico Jaime Isaza Cadavid",
                "Harvard"
            };
        }
        public override bool IsValid(object value)
        {
            return UniversityName.Contains((string)value);
        }
    }
}
