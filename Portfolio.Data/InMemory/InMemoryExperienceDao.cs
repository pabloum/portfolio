using Portfolio.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Portfolio.Data.InMemory
{
    public class InMemoryExperienceDao : IRepository<Experience>
    {
        private List<Experience> Experience { get; set; }

        public InMemoryExperienceDao()
        {
            Experience = new List<Experience>
            {
                new Experience {Id = 1,  Company = "Globant", MainFunctions = "Develop new functionalities", Position = ".Net Developer", Technologies = ".Net Core, SQL Server, AWS"},
                new Experience {Id = 2, Company = "Globant", MainFunctions = "Develop new functionalities", Position = "C++ Developer", Technologies = "C++11 You.I."},
                new Experience {Id = 3, Company = "Renault - Sofasa", MainFunctions = "Ni mierda", Position = "Production Intern", Technologies = "Excel"}
            };
        }
        public IEnumerable<Experience> GetAll()
        {
            return Experience;
        }

        public void Create(Experience experience)
        {
            experience.Id = Experience.Max(e => e.Id) + 1;
            Experience.Add(experience);
        }

        public Experience Read(int id)
        {
            return Experience.Where(e => e.Id == id).FirstOrDefault();
        }

        public void Update(Experience experience)
        {
            var record = Experience.SingleOrDefault(r => r.Id == experience.Id);

            if (record != null) 
            {
                record.Company = experience.Company;
                record.MainFunctions = experience.MainFunctions;
                record.Position = experience.Position;
            }
        }

        public void Delete(Experience experience)
        {
            Experience.Remove(experience);
        }
    }
}
