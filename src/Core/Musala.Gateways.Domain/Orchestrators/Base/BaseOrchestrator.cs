using AutoMapper;

namespace Musala.Gateways.Domain.Orchestrators.Base
{
    public class BaseOrchestrator
    {
        public BaseOrchestrator(IMapper mapper)
        {
            Mapper = mapper;
        }
        public IMapper Mapper { get; }
    }
}
