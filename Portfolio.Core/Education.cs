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
    }
}
