using Microsoft.EntityFrameworkCore;
using Portfolio.Entities.Entities;

namespace Portfolio.Data.dbData
{
    public class SkillRepository : Repository<Skill>
    {
        public SkillRepository(DbContextOptions<PortfolioDbContext> db) : base(db)
        {
        }
    }
}
