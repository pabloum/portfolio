using System;
using System.Collections.Generic;

namespace Portfolio.Entities
{
    public class PersonalInformation
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public List<string> Professions { get; set; }
        public string Job { get; set; }
        public List<string> ProgrammingLanguages { get; set; }
        public List<string> NaturalLanguages { get; set; }

        public int GetAge()
        {
            DateTime zeroTime = new DateTime(1, 1, 1);

            var span = DateTime.Now - Birthday;
            var age = (zeroTime + span).Year - 1;

            return age;
        }
    }
}
