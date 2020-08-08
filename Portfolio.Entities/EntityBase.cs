using AutoMapper;

namespace Portfolio.Entities
{
    public abstract class EntityBase
    {
        protected readonly IMapper _mapper;

        public EntityBase()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<EntitiesProfiler>());
            _mapper = new Mapper(configuration);
        }
    }
}
