using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Core.DTOs
{
    public class ExperienceDto
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string MainFunctions { get; set; }
        public string Technologies { get; set; }
        public DateTime DateBegining { get; set; }
        public DateTime DateEnd { get; set; }
        public decimal YearsExperience { get; set; }

        public Experience ToEntity()
        {
            return new Experience
            {
                Id              = this.Id,
                Company         = this.Company,
                Position        = this.Position,
                MainFunctions   = this.MainFunctions,
                Technologies    = this.Technologies,
                DateBegining    = this.DateBegining,
                DateEnd         = this.DateEnd,
                YearsExperience = this.YearsExperience
            };
        }
    }
}
