using Agriculture.Shared.Application.Abstractions.Mapper;
using MapsterMapper;

namespace Agriculture.Shared.Infrastructure.Implementations.Mapper
{
    public class AgricultureMapper : IAgricultureMapper
    {
        private readonly IMapper _mapper;

        public AgricultureMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TDestination>(object source)
        {
            var destination = _mapper.Map<TDestination>(source);

            return destination;
        }

        public void Map(object source, object destination)
        {
            _mapper.Map(source, destination);
        }
    }
}
