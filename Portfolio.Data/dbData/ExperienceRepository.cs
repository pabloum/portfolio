using Microsoft.EntityFrameworkCore;
using Portfolio.Entities.Entities;

namespace Portfolio.Data.dbData
{
    public class ExperienceRepository : Repository<Experience>
    {
        public ExperienceRepository(DbContextOptions<PortfolioDbContext> db) : base(db)
        {
        }
    }
}
