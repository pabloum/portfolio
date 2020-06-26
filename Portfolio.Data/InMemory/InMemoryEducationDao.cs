﻿using Portfolio.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Portfolio.Data
{
    public class InMemoryEducationDao : IRepository<Education>
    {
        public List<Education> Education { get; set; }

        public InMemoryEducationDao()
        {
            Education = new List<Education>
            {
                new Education { Id = 1, University = "Universidad Pontificia Bolivariana", Title = "Mechanical Engineer", DateBegining = DateTime.ParseExact("15/01/2011", "dd/MM/yyyy", null), DateEnd = DateTime.ParseExact("27/07/2017", "dd/MM/yyyy", null)},
                new Education { Id = 2, University = "Universidad Pontificia Bolivariana", Title = "Aeronautical Engineer", DateBegining = DateTime.ParseExact("15/01/2011", "dd/MM/yyyy", null), DateEnd = DateTime.ParseExact("27/07/2017", "dd/MM/yyyy", null)},
                new Education { Id = 3, University = "Make it Real", Title = "Full stack Web Development", DateBegining = DateTime.ParseExact("15/07/2018", "dd/MM/yyyy", null), DateEnd = DateTime.ParseExact("27/09/2018", "dd/MM/yyyy", null)}
            };
        }
        public IEnumerable<Education> GetAll()
        {
            return Education;
        }

        public void Create(Education education)
        {
            Education.Add(education);
        }

        public Education Read(int id)
        {
            return Education.Where(e => e.Id == id).FirstOrDefault();
        }

        public void Update(Education education)
        {
            var record = Education.SingleOrDefault(r => r.Id == education.Id);

            if (record != null) 
            {
                record.University = education.University;
                record.Title = education.Title;
                record.DateBegining = education.DateBegining;
                record.DateEnd = education.DateEnd;
            }
        }

        public void Delete(Education education)
        {
            Education.Remove(education);
        }
    }
}
