using AutoMapper;
using Portfolio.Entities.Setup;

namespace Portfolio.Entities.Base
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
