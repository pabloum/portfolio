using Microsoft.EntityFrameworkCore;
using Portfolio.Entities.Entities;

namespace Portfolio.Data.dbData
{
    public class ProjectRepository : Repository<Project>
    {
        public ProjectRepository(DbContextOptions<PortfolioDbContext> db) : base(db)
        {
        }
    }
}
