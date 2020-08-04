using System.Threading;
using MediatR;
using Musala.Gateways.Core.Responses;
using Musala.Gateways.Domain.Orchestrators;

namespace Musala.Gateways.Application.Gateway.Query.GetAllGateways

{
    public class GetAllGatewaysQueryHandler : IRequestHandler<GetAllGatewaysQuery, ApiResponse>
    {
        private readonly IGatewayOrchestrator _orchestrator;

        public GetAllGatewaysQueryHandler(IGatewayOrchestrator orchestrator)
        {
            _orchestrator = orchestrator;
        }

        public async System.Threading.Tasks.Task<ApiResponse> Handle(GetAllGatewaysQuery request, CancellationToken cancellationToken)
        {
            var response=new ApiResponse();
            response.Data=await _orchestrator.GetAllGateways();
            return response;
        }
    }
}