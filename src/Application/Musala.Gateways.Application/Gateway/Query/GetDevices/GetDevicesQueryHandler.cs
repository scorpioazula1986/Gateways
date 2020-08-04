using System.Threading;
using MediatR;
using Musala.Gateways.Core.Responses;
using Musala.Gateways.Domain.Orchestrators;

namespace Musala.Gateways.Application.Gateway.Query.GetDevices
{
    public class GetDevicesQueryHandler : IRequestHandler<GetDevicesQuery, ApiResponse>
    {
        private readonly IGatewayOrchestrator _orchestrator;

        public GetDevicesQueryHandler(IGatewayOrchestrator orchestrator)
        {
            _orchestrator = orchestrator;
        }

        public async System.Threading.Tasks.Task<ApiResponse> Handle(GetDevicesQuery request, CancellationToken cancellationToken)
        {
            var response=new ApiResponse();
            response.Data=await _orchestrator.GetDevices(request.Id);
            return response;
        }
    }
}