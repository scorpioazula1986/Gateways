using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Musala.Gateways.Core.Responses;
using Musala.Gateways.Domain.Orchestrators;

namespace Musala.Gateways.Application.Device.Command.DeleteDevice
{
    public class DeleteDeviceCommandHandler:IRequestHandler<DeleteDeviceCommand,ApiResponse>
    {
        private readonly IDeviceOrchestrator _deviceOrchestrator;

        public DeleteDeviceCommandHandler(IDeviceOrchestrator deviceOrchestrator)
        {
            _deviceOrchestrator = deviceOrchestrator;
        }
        public async Task<ApiResponse> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
        {
            await _deviceOrchestrator.DeleteDevice(request.Id);
            var response=new ApiResponse();
            response.Message = "OK";
            return response;
        }
    }
}