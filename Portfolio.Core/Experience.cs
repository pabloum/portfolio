using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Core
{
    public class Experience
    {
        public float GetYearsExperience()
        {
            YearsExperience = (float)Math.Round(((DateEnd - DateBegining).Days / 365.0f) * 100f) / 100f;
            return YearsExperience;
        }

        public int Id { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string MainFunctions { get; set; }
        public string Technologies { get; set; }
        public DateTime DateBegining { get; set; }
        public DateTime DateEnd { get; set; }
        public float YearsExperience { get; set; }
    }
}
