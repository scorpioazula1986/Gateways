using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Musala.Gateways.Core.Responses;
using Musala.Gateways.Domain.Orchestrators;

namespace Musala.Gateways.Application.Gateway.Command.AddGateway
{
    public class AddGatewayCommandHandler : IRequestHandler<AddGatewayCommand, ApiResponse>
    {
        private readonly IGatewayOrchestrator _orchestrator;

        public AddGatewayCommandHandler(IGatewayOrchestrator orchestrator)
        {
            _orchestrator = orchestrator;
        }

        public async Task<ApiResponse> Handle(AddGatewayCommand request, CancellationToken cancellationToken)
        {
            var response=new ApiResponse();
            await _orchestrator.AddGateway(request.Gateway);
            response.Message="Ok";
            return response;
        }
    }
}