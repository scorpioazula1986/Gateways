using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Musala.Gateways.Application.Device.Query.GetDevice;
using Musala.Gateways.Core.Responses;
using Musala.Gateways.Domain.Orchestrators;

namespace Musala.Gateways.Application.Gateway.Query.GetGateway
{
    public class GetGatewayQueryHandler:IRequestHandler<GetGatewayQuery,ApiResponse>
    {
        private readonly IGatewayOrchestrator _orchestrator;

        public GetGatewayQueryHandler(IGatewayOrchestrator orchestrator)
        {
            _orchestrator = orchestrator;
        }
        public async Task<ApiResponse> Handle(GetGatewayQuery request, CancellationToken cancellationToken)
        {
            var response=new ApiResponse();
            response.Data = await _orchestrator.GetGateway(request.Id);
            return response;
        }
    }
}