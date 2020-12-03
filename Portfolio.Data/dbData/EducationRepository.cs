using Microsoft.EntityFrameworkCore;
using Portfolio.Entities.Entities;

namespace Portfolio.Data.dbData
{
    public class EducationRepository : Repository<Education>
    {
        public EducationRepository(DbContextOptions<PortfolioDbContext> db) : base(db)
        {
        }
    }
}
