using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Musala.Gateways.Core.Responses;
using Musala.Gateways.Domain.Orchestrators;

namespace Musala.Gateways.Application.Device.Command.AddDevice
{
    public class AddDeviceCommandHandler:IRequestHandler<AddDeviceCommand,ApiResponse>
    {
        private readonly IDeviceOrchestrator _deviceOrchestrator;

        public AddDeviceCommandHandler(IDeviceOrchestrator deviceOrchestrator)
        {
            _deviceOrchestrator = deviceOrchestrator;
        }


        public async Task<ApiResponse> Handle(AddDeviceCommand request, CancellationToken cancellationToken)
        {
            await _deviceOrchestrator.AddDevice(request.Device);
            var response=new ApiResponse();
            response.Message = "OK";
            return response;
        }
    }
}