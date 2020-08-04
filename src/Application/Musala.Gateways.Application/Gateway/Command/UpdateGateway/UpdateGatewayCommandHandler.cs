using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Musala.Gateways.Core.Responses;
using Musala.Gateways.Domain.Orchestrators;

namespace Musala.Gateways.Application.Gateway.Command.UpdateGateway
{
    public class UpdateGatewayCommandHandler : IRequestHandler<UpdateGatewayCommand, ApiResponse>
    {
        private readonly IGatewayOrchestrator _orchestrator;

        public UpdateGatewayCommandHandler(IGatewayOrchestrator orchestrator)
        {
            _orchestrator = orchestrator;
        }

        public async Task<ApiResponse> Handle(UpdateGatewayCommand request, CancellationToken cancellationToken)
        {
            await _orchestrator.UpdateGateway(request.Id,request.Gateway);
            var response=new ApiResponse();
            response.Message="OK";
            return response;
        }
    }
}