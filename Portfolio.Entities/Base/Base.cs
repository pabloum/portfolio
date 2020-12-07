using AutoMapper;
using Portfolio.Entities.Setup;

namespace Portfolio.Entities.Base
{
    public abstract class Base
    {
        protected readonly IMapper _mapper;
        public int Id { get; set; }

        public Base()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<EntitiesProfiler>());
            _mapper = new Mapper(configuration);
        }
    }
}
