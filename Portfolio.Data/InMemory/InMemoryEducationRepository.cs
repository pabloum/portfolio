using Portfolio.Entities.Entities;
using System;
using System.Collections.Generic;

namespace Portfolio.Data.InMemory
{
    public class InMemoryEducationRepository : InMemoryRepository<Education>
    {
        public InMemoryEducationRepository()
        {
            Entities = new List<Education>
            {
                new Education { Id = 1, University = "Universidad Pontificia Bolivariana", Title = "Mechanical Engineer", DateBegining = DateTime.ParseExact("15/01/2011", "dd/MM/yyyy", null), DateEnd = DateTime.ParseExact("27/07/2017", "dd/MM/yyyy", null), Description = "Machines"},
                new Education { Id = 2, University = "Universidad Pontificia Bolivariana", Title = "Aeronautical Engineer", DateBegining = DateTime.ParseExact("15/01/2011", "dd/MM/yyyy", null), DateEnd = DateTime.ParseExact("27/07/2017", "dd/MM/yyyy", null), Description = "Aircrafts"},
                new Education { Id = 3, University = "Make it Real", Title = "Full stack Web Development", DateBegining = DateTime.ParseExact("15/07/2018", "dd/MM/yyyy", null), DateEnd = DateTime.ParseExact("27/09/2018", "dd/MM/yyyy", null), Description = "Web programming"}
            };
        }
    }
}
