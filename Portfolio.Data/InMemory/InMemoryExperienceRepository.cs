using Portfolio.Entities.Entities;
using System;
using System.Collections.Generic;

namespace Portfolio.Data.InMemory
{
    public class InMemoryExperienceRepository : InMemoryRepository<Experience>
    {
        public InMemoryExperienceRepository()
        {
            Entities = new List<Experience>
            {
                new Experience {Id = 1,  Company = "Globant", MainFunctions = "Develop new functionalities", Position = ".Net Developer", Technologies = ".Net Core, SQL Server, AWS", DateBegining = new DateTime(2020,1,1), DateEnd = DateTime.Now},
                new Experience {Id = 2, Company = "Globant", MainFunctions = "Develop new functionalities", Position = "C++ Developer", Technologies = "C++11 You.I.", DateBegining = new DateTime(2018,11,7), DateEnd = new DateTime(2019,12,31)},
                new Experience {Id = 3, Company = "Renault - Sofasa", MainFunctions = "Ni mierda", Position = "Production Intern", Technologies = "Excel", DateBegining = new DateTime(2017,1,10), DateEnd = new DateTime(2017,7,7)}
            };
        }
    }
}
