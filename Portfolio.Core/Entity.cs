using AutoMapper;

namespace Portfolio.Core.DTOs
{
    public class Entity
    {
        protected readonly IMapper _mapper;

        public Entity()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<EntitiesProfiler>());
            _mapper = new Mapper(configuration);
        }
    }
}
