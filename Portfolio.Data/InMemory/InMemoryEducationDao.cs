using Portfolio.Data.Utility;
using Portfolio.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Portfolio.Data.InMemory
{
    public class InMemoryEducationDao : IDao<Education>
    {
        private List<Education> Education { get; set; }

        public InMemoryEducationDao()
        {
            Education = new List<Education>
            {
                new Education { Id = 1, University = "Universidad Pontificia Bolivariana", Title = "Mechanical Engineer", DateBegining = DateTime.ParseExact("15/01/2011", "dd/MM/yyyy", null), DateEnd = DateTime.ParseExact("27/07/2017", "dd/MM/yyyy", null), Description = "Machines"},
                new Education { Id = 2, University = "Universidad Pontificia Bolivariana", Title = "Aeronautical Engineer", DateBegining = DateTime.ParseExact("15/01/2011", "dd/MM/yyyy", null), DateEnd = DateTime.ParseExact("27/07/2017", "dd/MM/yyyy", null), Description = "Aircrafts"},
                new Education { Id = 3, University = "Make it Real", Title = "Full stack Web Development", DateBegining = DateTime.ParseExact("15/07/2018", "dd/MM/yyyy", null), DateEnd = DateTime.ParseExact("27/09/2018", "dd/MM/yyyy", null), Description = "Web programming"}
            };
        }
        public IEnumerable<Education> GetAll()
        {
            return Education;
        }

        public int Commit()
        {
            return 0;
        }

        public Education Create(Education education)
        {
            education.Id = Education.Max(e => e.Id) + 1;
            Education.Add(education);
            return education;
        }

        public Education Read(int id)
        {
            return Education.Where(e => e.Id == id).FirstOrDefault();
        }

        public Education Update(Education education)
        {
            var record = Education.SingleOrDefault(r => r.Id == education.Id);

            if (record != null) 
            {
                Education.ReplaceWith(record,education);
            }

            return record;
        }

        public void Delete(Education education)
        {
            Education.Remove(education);
        }
    }
}
