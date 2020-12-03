using Portfolio.Entities.Entities;
using System.Collections.Generic;

namespace Portfolio.Data.InMemory
{
    public class InMemoryProjectRepository : InMemoryRepository<Project>
    {
        public InMemoryProjectRepository()
        {
            Entities = new List<Project> 
            {
                new Project { Id = 1, ProjectName = "My Portfolio",     Description = "OMG", Technologies = ".Net Core, SQL, C#, HTML, JS, CSS" },
                new Project { Id = 2, ProjectName = "Flowoverstack",    Description = "OMG", Technologies = "Ruby on Rails, HTML, JS, CSS" },
                new Project { Id = 3, ProjectName = "Notes bloc",       Description = "OMG", Technologies = "Ruby on Rails, HTML, JS, CSS" },
                new Project { Id = 4, ProjectName = "Guess the number", Description = "OMG", Technologies = "HTML, JS, CSS" },
                new Project { Id = 5, ProjectName = "Vigenere Cypher",  Description = "OMG", Technologies = "HTML, JS, CSS" },
            };
        }
    }
}
