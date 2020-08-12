using Portfolio.Entities.Base;
using Portfolio.Entities.Entities;

namespace Portfolio.Entities.DTOs
{
    public class SkillDto : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SkillType Category { get; set; }
        public int Percentage { get; set; }

        public Skill ToEntity()
        {
            return _mapper.Map<Skill>(this);
        }
    }
}
