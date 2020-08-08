using Portfolio.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Data.InMemory
{
    public class InMemoryProjectDao : IRepository<Project>
    {
        private List<Project> Projects { get; set; }
        public InMemoryProjectDao()
        {
            Projects = new List<Project>
            {
                new Project { Id = 1, ProjectName = "My Portfolio",     Description = "OMG", Technologies = ".Net Core, SQL, C#, HTML, JS, CSS" },
                new Project { Id = 2, ProjectName = "Flowoverstack",    Description = "OMG", Technologies = "Ruby on Rails, HTML, JS, CSS" },
                new Project { Id = 3, ProjectName = "Notes bloc",       Description = "OMG", Technologies = "Ruby on Rails, HTML, JS, CSS" },
                new Project { Id = 4, ProjectName = "Guess the number", Description = "OMG", Technologies = "HTML, JS, CSS" },
                new Project { Id = 5, ProjectName = "Vigenere Cypher",  Description = "OMG", Technologies = "HTML, JS, CSS" },
            };
        }
        public int Commit()
        {
            return 0;
        }

        public void Create(Project project)
        {
            project.Id = Projects.Max(p => p.Id) + 1;
            Projects.Add(project);
        }

        public Project Read(int id)
        {
            return Projects.Where(p => p.Id == id).FirstOrDefault();
        }

        public void Update(Project project)
        {
            var result = Projects.Where(p => p.Id == project.Id).FirstOrDefault();

            if (result != null)
            {
                result.ProjectName = project.ProjectName;
                result.Technologies = project.Technologies;
                result.Description = project.Description;
            }
        }

        public void Delete(Project project)
        {
            Projects.Remove(project);
        }

        public IEnumerable<Project> GetAll()
        {
            return Projects;
        }
    }
}
