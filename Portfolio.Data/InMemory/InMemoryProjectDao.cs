using Portfolio.Core;
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

            };
        }
        public void Create(Project project)
        {
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
                // TODO. I'm not sure if this solution works
                result = project;
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
